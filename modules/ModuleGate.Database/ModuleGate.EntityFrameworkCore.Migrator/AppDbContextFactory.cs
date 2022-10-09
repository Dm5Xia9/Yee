using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ModuleGate.EntityFrameworkCore.Identity;
using System;

namespace ModuleGate.EntityFrameworkCore.Migrator
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AbilityIdentityDbContext>
    {
        public AbilityIdentityDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            var npgefStartup = new ModuleGate.EntityFrameworkCore.Npgsql.Startup();
            npgefStartup.ConfigureServices(services);

            var targetStartup = new ModuleGate.EntityFrameworkCore.Identity.Startup();
            targetStartup.ConfigureServices(services);

            var provider = services.BuildServiceProvider(true);
            var scope = provider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<AbilityIdentityDbContext>();
        }
    }
}
