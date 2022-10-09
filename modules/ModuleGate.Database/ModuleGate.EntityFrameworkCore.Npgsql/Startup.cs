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
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<NpgsqlOptions>(p => new NpgsqlOptions
            {
                ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=QAZqaz_123;Pooling=true;",
                Timeout = 600
            });
            services.AddScoped<IDbContextOptionsProvider, NpgsqlOptionsProvider>();
        }
    }
}
