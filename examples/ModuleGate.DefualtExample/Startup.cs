using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ModuelGate.Options.Extensions;
using ModuleGate.Attributes;
using ModuleGate.DefualtExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.DefualtExample
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WeatherForecastService>();
            services.AddFlexOptions<Flex>();
        }
    }

    public class Flex
    {
        public string Value { get; set; }
    }
}
    