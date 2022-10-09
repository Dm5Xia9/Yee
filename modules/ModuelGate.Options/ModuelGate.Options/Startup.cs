using Microsoft.Extensions.DependencyInjection;
using ModuleGate;
using ModuleGate.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuelGate.Options
{
    public class Startup : ModuleStartup
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<FlexOptionsFactory>();
            services.AddScoped<IFlexOptionsProvider, DefualtProvider>();
            base.ConfigureServices(services);
        }
    }
}
