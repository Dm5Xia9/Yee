using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.Ant
{
    public class Startup : ModuleStartup
    {
        public override void Deps(List<Assembly> assemblies)
        {
            assemblies.Add(typeof(AntDesign.Alert).Assembly);
        }


        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAntDesign();
        }
    }
}
