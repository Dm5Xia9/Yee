using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ModuleGate.Attributes;
using ModuleGate.Models;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.Nupkg;
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
        private readonly NupkgStorage _nupkgStorage;
        private readonly CombineNugetRepository _combineNugetRepository;
        public NupkgPackageProvider(NupkgOptions options, NupkgStorage storage)
        {
            _nupkgStorage = storage;
            Context = new AssemblyLoadContext("nupkg", true);
            Context.Resolving += Context_Resolving;

            
            _combineNugetRepository = 
                new CombineNugetRepository(
                    options.Sources.Select(p => new NugetRepository(p)).ToArray());
        }

        private System.Reflection.Assembly? Context_Resolving
            (AssemblyLoadContext arg1, System.Reflection.AssemblyName arg2)
        {
            var assemblyPath = _nupkgStorage
                .GetAssemblyPathFromAssemblyName(arg2, _combineNugetRepository)
                .Result;

            if (assemblyPath == null)
                return null;

            return Context.LoadFromAssemblyPath(assemblyPath);
        }

        public ModulePackage? Load(IWebHostEnvironment webHost,
            MgModuleMetadata mgModule)
        {
            Assembly assembly;
            if (mgModule.Assembly == null)
            {
                if (string.IsNullOrEmpty(mgModule.Source))
                {
                    mgModule.Source = ResolveAssemblyPathModule(mgModule.NugetSource,
                        new AssemblyName(mgModule.ModuleName)
                        {
                            Version = new Version(mgModule.ModuleVersion)
                        }).Result;
                }


                if (string.IsNullOrEmpty(mgModule.Source))
                {
                    throw new Exception("Не могу найти пакет");
                }

                assembly = Context.LoadFromAssemblyPath(mgModule.Source);

            }
            else
            {
                assembly = mgModule.Assembly;
            }

            if (IsModuleGateAssembly(assembly) == false)
                throw new AggregateException("this is not a module");

            return LoadFromAssembly(assembly);
        }

        private ModulePackage LoadFromAssembly(Assembly assembly)
        {
            ModulePackage depNodeAssembly = new ModulePackage();
            depNodeAssembly.Target = assembly;
            depNodeAssembly.TargetName = assembly.GetName();
            depNodeAssembly.Startup = SharpModuleElementLoader.LoadStartup(assembly);
            depNodeAssembly.Patch = SharpModuleElementLoader.LoadPatch(assembly);
            depNodeAssembly.ChildPackages = new List<ModulePackage>();
            var deps = assembly.GetReferencedAssemblies();
            foreach (var dep in deps)
            {
                Assembly depAs;
                try
                {
                    if (Context.Assemblies.Any(p => p.GetName().Name == dep.Name))
                        continue;

                    depAs = Context.LoadFromAssemblyName(dep);
                }
                catch (FileNotFoundException ex)
                {
                    continue;
                }

                if (IsModuleGateAssembly(depAs))
                {
                    depNodeAssembly.ChildPackages.Add(LoadFromAssembly(depAs));
                }
            }

            return depNodeAssembly;
        }


        private bool IsModuleGateAssembly(Assembly assembly)
        {
            return assembly.CustomAttributes.Any(p => p.AttributeType == typeof(ModuleGateAttribute));
        }

        public async Task<string> ResolveAssemblyPathModule(string source, AssemblyName assemblyName)
        {
            return await _nupkgStorage
                .GetAssemblyPathFromAssemblyName(assemblyName,
                    new NugetRepository(source));
        }
    }
}
