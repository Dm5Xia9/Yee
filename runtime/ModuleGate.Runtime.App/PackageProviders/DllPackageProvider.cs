using ModuleGate.Attributes;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.Nupkg;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.PackageProviders
{
    public class DllPackageProvider : IPackageProvider
    {
        public string FileExtension => ".dll";
        public static AssemblyLoadContext Context;

        static DllPackageProvider()
        {
            Context = new AssemblyLoadContext("root", true);

            Context.Resolving += Context_Resolving;
        }

        private static Assembly? Context_Resolving(AssemblyLoadContext arg1, 
            AssemblyName arg2)
        {
            //next();
            return Task.Run<Assembly>(async () => 
            {
                var path = AllModules
                .FirstOrDefault(p => Path.GetFileNameWithoutExtension(p) == arg2.Name);

                if (path == null)
                {
                    var storage = new NupkgStorage("C:\\Users\\jackf\\Documents\\ModuleGate\\test\\data",
                        new NugetRepository("https://api.nuget.org/v3/index.json"));

                    var assemblyPath = await storage.GetAssemblyPathFromAssemblyName(arg2);
                    if (assemblyPath == null)
                        return null;

                    return Context.LoadFromAssemblyPath(assemblyPath);
                }

                var r = arg1.LoadFromAssemblyPath(path);

                return r;
            }).Result;
            
        }

        public static List<string> AllModules { get; set; }
            = new List<string>();
        public ModulePackage Load(string path, Action next)
        {
            var assembly = Context.LoadFromAssemblyPath(path);

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
    }
}
