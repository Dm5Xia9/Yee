using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Attributes;
using ModuleGate.Configuration;
using ModuleGate.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.EntityFrameworkCore.Npgsql
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(ModuleConfiguration configuration, IServiceCollection services)
        {
            services.Configure<NpgsqlOptions>(configuration);
            services.AddScoped<IDbContextOptionsProvider, NpgsqlOptionsProvider>();
        }
    }
}
