using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Abstractions;
using ModuleGate.Configuration;
using ModuleGate.Middlewares;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Builder
{
    public class MGRuntimeApplicationBuilder
    {
        private string[] _args;
        private List<string> _modules = new List<string>();
        private List<IPackageProvider> _providers = new List<IPackageProvider>();
        public MGRuntimeApplicationBuilder(string[] args, IConfiguration configuration)
        {
            _args = args;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; internal set; }
        public Action<IServiceCollection> CustomServices { get; set; }

        public MGRuntimeApplicationBuilder AddModule(string moduleFile)
        {
            _modules.Add(moduleFile);
            return this;
        }
        public MGRuntimeApplicationBuilder AddProvider(IPackageProvider provider)
        {
            _providers.Add(provider);
            return this;
        }

        public MGRuntimeApplication Build()
        {
            var loader = new PackageLoader(_providers);
            List<ModulePackage> packages = new List<ModulePackage>();
            foreach(var module in _modules)
            {
                packages.Add(loader.Load(module));
            }

            var qeneralize = ModulePackageHelper.Generalize(packages);

            var builder = WebApplication.CreateBuilder(_args);
            builder.Environment
                .UseStaticWebAssetsFromAssemblies(builder.Configuration, qeneralize.Assemblies.ToArray());

            qeneralize.Startups.ForEach(p => p.ConfigureBuilder(builder));
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<IMetaModuleGate, MetaModuleGate>();
            qeneralize.Startups.ForEach(p => p.ConfigureBuilder(builder));
            builder.Services.AddSingleton(qeneralize);
            builder.Services.AddSingleton(HostConfiguration.FromStaticFileGroup(qeneralize.ModulePatch.RootStaticFiles));
            qeneralize.Startups.ForEach(p => p.ConfigureServices(new ModuleConfiguration(), builder.Services));
            var app = builder.Build();
            var service = app.Services.GetRequiredService<IMetaModuleGate>() as MetaModuleGate;
            service!.SetServices(builder.Services);

            qeneralize.Startups.ForEach(p => p.Build(app.Services));

            var middleBuilder = new MiddlewareBuilder();
            middleBuilder.AddLast(new MiddleNotDevelopment());
            middleBuilder.AddLast(new MiddleStaticFiles());
            middleBuilder.AddLast(new MiddleRouting());
            middleBuilder.AddLast(new MiddleBlazor("/_Host"));
            qeneralize.Startups.ForEach(p => p.Configure(middleBuilder));
            foreach (var middle in middleBuilder)
            {
                middle.Next(app);
            }

            return new MGRuntimeApplication
            {
                App = app
            };
        }
    }
}
