using ModuleGate.Runtime.App.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Helpers
{
    public static class ModulePackageHelper
    {
        public static ModulePackageGeneralize Generalize(IEnumerable<ModulePackage> packages)
        {
            var linePackages = TreeToLine(packages);

            var generalize = new ModulePackageGeneralize();
            generalize.Startups = linePackages
                .Where(p => p.Startup != null)
                .Select(p => p.Startup)
                .ToList();

            var patches = linePackages
                .Select(p => p.Patch)
                .ToList();

            generalize.ModulePatch = new ModulePatch
            {
                RootStaticFiles = new Models.StaticFileGroup(null, patches
                    .SelectMany(p => p.RootStaticFiles).ToList()),
                AppComponentTypes = patches.SelectMany(p => p.AppComponentTypes).ToList()

            };

            generalize.Assemblies = linePackages.Select(p => p.Target).ToList();
            return generalize;
        }

        private static List<ModulePackage> TreeToLine(IEnumerable<ModulePackage> packages)
        {
            var root = new List<ModulePackage>();

            foreach(var package in packages)
            {
                root.Add(package);

                if(package.ChildPackages != null && package.ChildPackages.Any())
                {
                    root.AddRange(package.ChildPackages);
                }
            }

            return root;
        }
    }

    public class ModulePackageGeneralize
    {
        public List<Assembly> Assemblies { get; set; }
        public List<ModuleStartup> Startups { get; set; }
        public ModulePatch ModulePatch { get; set; }
    }
}
