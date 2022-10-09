using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.FileProviders;
using ModuleGate.Attributes;
using ModuleGate.Models;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.Nupkg;
using NuGet.Packaging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.PackageProviders
{
    public class NupkgPackageProvider : IPackageProvider
    {
        public readonly AssemblyLoadContext Context;

        private readonly List<ModulePackage> _cache = new List<ModulePackage>();
        private readonly NupkgStorage _nupkgStorage;
        private readonly CombineNugetRepository _combineNugetRepository;
        public NupkgPackageProvider(NupkgOptions options, NupkgStorage storage)
        {
            _nupkgStorage = storage;
            Context = new AssemblyLoadContext("nupkg", true);
            Context.Resolving += Context_Resolving;
            //Context.Resolving += Context_ResolvingFromNuGet; ;

            _combineNugetRepository = 
                new CombineNugetRepository(
                    options.Sources.Select(p => new NugetRepository(p)).ToArray());
        }

        //private Assembly? Context_ResolvingFromNuGet(AssemblyLoadContext arg1, AssemblyName arg2)
        //{
        //    return Task.Run(async () =>
        //    {
        //        var all = await _nupkgStorage.SearchDependency(new NugetPacket
        //        {
        //            Id = CurrentAssemblyName.Name!,
        //            Version = CurrentAssemblyName.Version!.ToString()
        //        }, _combineNugetRepository);

        //        var lib = all.FirstOrDefault(p => p.Id == arg2.Name);

        //        if (lib == null)
        //            return Context.LoadFromAssemblyName(arg2);
        //        var assemblyPath = _nupkgStorage
        //             .GetAssemblyMetadataFromAssemblyName(new NugetPacket
        //             {
        //                 Id = lib.Id,
        //                 Version = lib.VersionRange.OriginalString
        //             },
        //             _combineNugetRepository)
        //             .Result;

        //        if (assemblyPath == null)
        //            return null;

        //        return GetAssemblyByMetadata(assemblyPath);
        //    }).Result;
             
        //}

        
        private System.Reflection.Assembly? Context_Resolving
            (AssemblyLoadContext arg1, System.Reflection.AssemblyName arg2)
        {

            return Task.Run(async () =>
            {
                var realVersion = await GetRealVersion(arg2);
                var assemblyPath = _nupkgStorage
                    .GetAssemblyMetadataFromAssemblyName(new NugetPacket
                    {
                        Id = arg2.Name,
                        Version = realVersion
                    }, _combineNugetRepository)
                    .Result;

                if (assemblyPath == null)
                    return null;


                return GetAssemblyByMetadata(assemblyPath);
            }).Result;
        }

        private async Task<string> GetRealVersion(AssemblyName assemblyName)
        {
            var all = await _nupkgStorage.SearchDependency(new NugetPacket
            {
                Id = CurrentAssemblyName.Name!,
                Version = CurrentAssemblyName.Version!.ToString()
            }, _combineNugetRepository);

            var lib = all.FirstOrDefault(p => p.Id == assemblyName.Name);
            if (lib == null)
                throw new Exception();

            return lib.VersionRange.OriginalString;
        }


        private Assembly GetAssemblyByMetadata(MgModuleMetadata mgModuleMetadata)
        {
            if (mgModuleMetadata.StaticWebAssetsPath != null)
            {
                _webHost.WebRootFileProvider =
                    new CompositeFileProvider(_webHost.WebRootFileProvider,
                    new PhysicalFileProvider(mgModuleMetadata.StaticWebAssetsPath));
            }

            return Context.LoadFromAssemblyPath(mgModuleMetadata.Source);
        }

        private IWebHostEnvironment _webHost;
        public ModulePackage? Load(IWebHostEnvironment webHost,
            MgModuleMetadata mgModule)
        {
            _webHost = webHost;
            Assembly assembly;
            if (mgModule.Assembly == null)
            {
                mgModule = ResolveFromMetadata(mgModule);

                if (mgModule.StaticWebAssetsPath != null)
                {
                    _webHost.WebRootFileProvider =
                        new CompositeFileProvider(_webHost.WebRootFileProvider,
                        new PhysicalFileProvider(mgModule.StaticWebAssetsPath));
                }

                assembly = Context.LoadFromAssemblyPath(mgModule.Source);

            }
            else
            {
                assembly = mgModule.Assembly;
            }

            //if (IsModuleGateAssembly(assembly) == false)
            //    throw new AggregateException("this is not a module");
            CurrentAssemblyName = assembly.GetName();

            var packet = LoadFromAssembly(assembly);
            return packet.Result;
        }


        public MgModuleMetadata ResolveFromMetadata(MgModuleMetadata input)
        {
            if (string.IsNullOrEmpty(input.Source))
            {
                input = ResolveAssemblyPathModule(input.NugetSource,
                    new NugetPacket
                    {
                        Id = input.ModuleName,
                        Version = input.ModuleVersion
                    }).Result;
            }


            if (string.IsNullOrEmpty(input.Source))
            {
                throw new Exception("Не могу найти пакет");
            }
            return input;

        }
        public AssemblyName CurrentAssemblyName { get; set; }
        private async Task<ModulePackage> LoadFromAssembly(Assembly assembly, bool resolveStaticAssets = false)
        {
            if (_cache.Any(p => p.Target == assembly))
                return _cache
                    .First(p => p.Target == assembly);


            if (resolveStaticAssets)
            {
                var realVersion = await GetRealVersion(assembly.GetName());

                var mgModule = await _nupkgStorage
                    .GetAssemblyMetadataFromAssemblyName(new NugetPacket
                    {
                        Id = assembly.GetName().Name,
                        Version = realVersion,
                    }, _combineNugetRepository);

                if (mgModule.StaticWebAssetsPath != null)
                {
                    _webHost.WebRootFileProvider =
                        new CompositeFileProvider(_webHost.WebRootFileProvider,
                        new PhysicalFileProvider(mgModule.StaticWebAssetsPath));
                }
            }
            ModulePackage depNodeAssembly = new ModulePackage();
            depNodeAssembly.Target = assembly;
            depNodeAssembly.TargetName = assembly.GetName();
            depNodeAssembly.Startup = SharpModuleElementLoader.LoadStartup(assembly);

            var appDeps = new List<Assembly>();

            if (depNodeAssembly.Startup != null)
                depNodeAssembly.Startup.Deps(appDeps);


            depNodeAssembly.Patch = SharpModuleElementLoader.LoadPatch(assembly);
            depNodeAssembly.ChildPackages = new List<ModulePackage>();
            var deps = assembly.GetReferencedAssemblies();

            _cache.Add(depNodeAssembly);
            foreach (var dep in deps.Where(p => !p.Name!.StartsWith("System.")))
            {
                Assembly depAs;
                try
                {
                    if (!Context.Assemblies.Any(p => p.GetName().Name == dep.Name))
                    {
                        depAs = Context.LoadFromAssemblyName(dep);

                    }
                    else
                    {
                        depAs = Context.Assemblies.First(p => p.GetName().Name == dep.Name);
                    }

                }
                catch (FileNotFoundException ex)
                {
                    continue;
                }

                if (IsModuleGateAssembly(depAs) || appDeps.Contains(depAs))
                {
                    depNodeAssembly.ChildPackages.Add(await LoadFromAssembly(depAs, true));
                }
            }

            return depNodeAssembly;
        }



        private bool IsModuleGateAssembly(Assembly assembly)
        {
            return assembly.CustomAttributes.Any(p => p.AttributeType == typeof(ModuleGateAttribute));
        }

        public async Task<MgModuleMetadata> ResolveAssemblyPathModule(string source, NugetPacket assemblyName)
        {
            return await _nupkgStorage
                .GetAssemblyMetadataFromAssemblyName(assemblyName,
                    new NugetRepository(source));
        }
    }
}
