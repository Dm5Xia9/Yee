using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleGate.Abstractions;
using ModuleGate.Configuration;
using ModuleGate.Middlewares;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.PackageProviders;
using ModuleGate.Services;
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
        private string _rootPath;
        private string _inputPath;
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

        public MGRuntimeApplicationBuilder AddRootPath(string rootPath)
        {
            _rootPath = rootPath;
            return this;
        }

        public MGRuntimeApplicationBuilder AddInputPath(string inputPath)
        {
            _inputPath = inputPath;
            return this;
        }

        public MGRuntimeApplication Build()
        {
            var mgService = new ModuleGateService(_rootPath, _inputPath);
            var storage = mgService.GetStorage("root");
            foreach (var module in storage.GetAllModules())
                AddModule(module);


            var loader = new PackageLoader(_providers);
            List<ModulePackage> packages = new List<ModulePackage>();

            if (_modules.Any())
            {
                loader.SetAll(_modules);
                DllPackageProvider.AllModules
                    .AddRange(_modules);
                foreach (var module in _modules)
                {
                    packages.Add(loader.Load(module, null));
                }
            }
            else
            {
                var starterAssembly = typeof(ModuleGate.App.Starter.Startup).Assembly;

                packages.Add(loader.Load(starterAssembly.Location, null));
            }

            var qeneralize = ModulePackageHelper.Generalize(packages);

            var builder = WebApplication.CreateBuilder(_args);
            builder.Environment
                .UseStaticWebAssetsFromAssemblies(builder.Configuration, qeneralize.Assemblies.ToArray());

            
            qeneralize.Startups.ForEach(p => p.ConfigureBuilder(builder));
            builder.Services.AddRazorPages();
            builder.Services.AddScoped(p => new ReloadService(_args, p
                    .GetRequiredService<IHostApplicationLifetime>()));
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton(mgService);
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
