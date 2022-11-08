using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Options;
using Yee.Runtime.Builder.Helpers;
using Yee.Services;
using Yee.Web.Middlewares;
using Yee.Web;
using Yee.Web.Extensions;
using Yee.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Yee.Runtime.Builder
{
    public class YeeApplicationBuilder
    {

        public YeeApplicationBuilder(string[] args)
        {
            WebBuilder = WebApplication.CreateBuilder(args);
            Services = new ServiceCollection();
            Services.AddSingleton(WebBuilder.Environment);
            var manager = new ConfigurationManager();

            var dirExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dir = Path.Combine(dirExe, "options");

            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);

            manager.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"OptionsDirectory", dir }
            });

            Services.Configure<RootOptions>(manager);
            Services.AddSingleton<IRootOptions, FileSystemRootOptions>();
            Services.AddSingleton<YeeModuleManager>();
            Services.AddSingleton<FileStorageCollection>();
        }

        public WebApplicationBuilder WebBuilder { get; init; }
        public IServiceCollection Services { get; init; }

        public void Build()
        {
            var provider = Services.BuildServiceProvider();

            var modules = provider.GetService<IEnumerable<BaseYeeModule>>();
            if(modules == null || modules.Any() == false)
            {
                modules = provider
                    .GetRequiredService<IYeeProvider<BaseYeeModule>>()
                    .Resolve();
            }

            var yeModuleManager = new YeeModuleManager(modules);
            WebBuilder.Services.AddScoped<LayoutState>();
            WebBuilder.Services.AddRange(Services);
            WebBuilder.Services.AddSingleton(yeModuleManager);
            WebBuilder.Services.AddRazorPages();
            WebBuilder.Services.AddServerSideBlazor();
            WebBuilder.Services.AddSingleton<ISourceService, SourceService>();
            WebBuilder.Services.AddSingleton<IForceHandler, ForceResolveHandler>();
            var alignmentModules = yeModuleManager.ToAlignmentTrees();
            foreach(var module in alignmentModules)
            {
                YeeBuilderHandler.Go 
                    (module.Builder, YeeBuilderTags.AspConfigureServices, WebBuilder.Services);

                YeeBuilderHandler.Go
                    (module.Builder, YeeBuilderTags.AspConfigureServicesAndModules, 
                    new ServiceCollectionAndModules
                    {
                        Services = WebBuilder.Services,
                        Modules = yeModuleManager
                    });
            }

            var app = WebBuilder.Build();

            var ss = app.Services.GetRequiredService<IRootOptions>();
            ss.GetAll();
            foreach (var module in alignmentModules)
            {
                YeeBuilderHandler.Go
                    (module.Builder, YeeBuilderTags.AspPostBuild, app.Services);
            }

            var middleBuilder = new MiddlewareBuilder(app.Services);
            middleBuilder.AddLast(new MiddleNotDevelopment());
            middleBuilder.AddLast(new MiddleStaticFiles());
            middleBuilder.AddLast(new MiddleRouting());
            middleBuilder.AddLast(new MiddleBlazor("/_Host"));
            foreach (var module in alignmentModules)
            {
                YeeBuilderHandler.Go
                    (module.Builder, YeeBuilderExtensions.TagAspConfigure, middleBuilder);
            }

            foreach (var middle in middleBuilder)
            {
                middle.Next(app);
            }

            app.Run();
        }
        
    }
}
