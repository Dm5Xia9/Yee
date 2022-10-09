using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: ModuleGate]

namespace ModuleGate.EntityFrameworkCore.Identity
{
    public class Startup : ModuleStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AbilityIdentityDbContext>();
            base.ConfigureServices(services);
        }

        public override void Finish(IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AbilityIdentityDbContext>();
            context.Database.Migrate();
        }
    }
}
