using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleGate.Abstractions;
using ModuleGate.Configuration;
using ModuleGate.Middlewares;
using ModuleGate.Models;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.Models;
using ModuleGate.Runtime.App.Nupkg;
using ModuleGate.Runtime.App.PackageProviders;
using ModuleGate.Runtime.App.RootOptions;
using ModuleGate.Services;
using NuGet.Packaging;
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
        public MGRuntimeApplicationBuilder(string[] args, IConfiguration configuration)
        {
            _args = args;
            Configuration = configuration;
            Services = new ServiceCollection();
            Services.AddSingleton<PackageLoader>();
            Services.AddSingleton<IRootOptions, FileSystemRootOptions>();
            Services.AddSingleton<IModuleStorage, NupkgModuleStorage>();
            Services.AddSingleton<ModuleGateStorage>();
            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<StarterOptions>();
            Services.AddSingleton<NupkgStorage>();
            Services.AddSingleton<NupkgOptions>();
            Services.AddSingleton<ModuleGateOptions>();
        }

        public IConfiguration Configuration { get; internal set; }
        public Action<IServiceCollection> CustomServices { get; set; }
        public IServiceCollection Services { get; set; }
        public MGRuntimeApplicationBuilder AddProvider<T>()
            where T :class, IPackageProvider
        {
            Services.AddSingleton<IPackageProvider, T>();
            return this;
        }


        public MGRuntimeApplication Build()
        {

            var internalProvider = Services.BuildServiceProvider();

            var storage = internalProvider.GetRequiredService<IModuleStorage>();
            var mgStorage = internalProvider.GetRequiredService<ModuleGateStorage>();
            var options = internalProvider.GetRequiredService<IRootOptions>();
            var nugetOptions = internalProvider.GetRequiredService<NupkgOptions>();

            var builder = WebApplication.CreateBuilder(_args);
            var packages = storage.Load(builder.Environment);

            var qeneralize = ModulePackageHelper.Generalize(packages);

            builder.Services.AddRange(Services);
            //builder.Environment
            //    .UseStaticWebAssetsFromAssemblies(builder.Configuration, qeneralize.Assemblies.ToArray());

            
            qeneralize.Startups.ForEach(p => p.ConfigureBuilder(builder));
            builder.Services.AddRazorPages();
            builder.Services.AddScoped(p => new ReloadService(_args, p
                    .GetRequiredService<IHostApplicationLifetime>()));
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton(options);
            builder.Services.AddSingleton(mgStorage);


            builder.Services.AddSingleton<INugetRepository>(new CombineNugetRepository(
                    nugetOptions.Sources.Select(p => new NugetRepository(p)).ToArray()));


            builder.Services.AddSingleton<IMetaModuleGate, MetaModuleGate>();
            qeneralize.Startups.ForEach(p => p.ConfigureBuilder(builder));
            builder.Services.AddSingleton(qeneralize);
            builder.Services.AddSingleton(HostConfiguration.FromStaticFileGroup(qeneralize.ModulePatch.RootStaticFiles));
            qeneralize.Startups.ForEach(p => p.ConfigureServices(builder.Services));
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

            qeneralize.Startups.ForEach(p => p.Finish(app.Services));

            return new MGRuntimeApplication
            {
                App = app
            };
        }
    }
}
