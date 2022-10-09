using Microsoft.Extensions.DependencyInjection;
using ModuelGate.Options.EntityFrameworkCore.Models;
using ModuleGate;
using ModuleGate.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuelGate.Options.EntityFrameworkCore
{
    public class Startup : ModuleStartup
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFlexOptionsProvider, OptionsProvider>();
            base.ConfigureServices(services);
        }

    }
}
