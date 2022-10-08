using ModuleGate.Attributes;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.PackageProviders
{
    public class DllPackageProvider : IPackageProvider
    {
        public string FileExtension => ".dll";

        public ModulePackage Load(string path)
        {
            var assembly = Assembly.LoadFrom(path);

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
                    depAs = Assembly.Load(dep);
                }
                catch (FileNotFoundException ex)
                {
                    continue;
                }

                if(IsModuleGateAssembly(depAs))
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
