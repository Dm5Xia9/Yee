using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Attributes;
using ModuleGate.Configuration;
using ModuleGate.Database.Abstraction;
using ModuleGate.EntityFrameworkCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.EntityFrameworkCore
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(ModuleConfiguration configuration, 
            IServiceCollection services)
        {
            services.Configure<EntityFrameworkDatabaseOptions>(configuration);
            services.AddSingleton<DatabaseAnotation>();
            services.AddScoped<DatabaseAnotationService>();
            services.AddScoped<DynamicAppDbContextBuilder>();
            services.AddScoped<DynamicAppDbContext>(p =>
                p.GetRequiredService<DynamicAppDbContextBuilder>().Create());
            services.AddScoped<IGateDbContext>(p => p.GetRequiredService<DynamicAppDbContext>());
        }
    }
}
