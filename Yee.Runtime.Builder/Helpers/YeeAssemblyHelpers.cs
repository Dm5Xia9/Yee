using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Runtime.Builder.Abstractions;

namespace Yee.Runtime.Builder.Helpers
{
    public static class YeeAssemblyHelpers
    {
        public static BaseYeeModule CreateDefualtModule(Assembly assembly)
        {
            var module = new DefualtYeeModule();
            module.Assembly = assembly;
            module.YeeModule = CreateYeeModule(assembly);
            module.Builder = new YeeBuilder();
            if (module.YeeModule == null)
                return module;

            module.YeeModule.Build(module.Builder);
            module.Deps = new List<BaseYeeModule>();
            foreach(var dep in GetDepsFromModule(module))
            {
                module.Deps.Add(CreateDefualtModule(dep));
            }

            return module;
        }
        public static IYeeModule CreateYeeModule(Assembly assembly)
        {
            var startupType = assembly.GetTypes()
                .FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IYeeModule)));

            if (startupType == null)
                return null;

            var constructor = startupType.GetConstructors().FirstOrDefault();

            if (constructor == null)
                return null;


            return (IYeeModule)constructor.Invoke(Array.Empty<object>());
        }
        public static bool IsYeeFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes()
                .Any(p => p.GetInterfaces().Contains(typeof(IYeeModule)));
        }

        public static List<Assembly> GetDepsFromModule(BaseYeeModule module)
        {
            List<Assembly> assemblies = new List<Assembly>();
            YeeBuilderHandler.Go(module.Builder, YeeBuilderTags.Deps, assemblies);

            return assemblies;
        }


    }

    internal class DefualtYeeModule : BaseYeeModule
    {

    }
}
