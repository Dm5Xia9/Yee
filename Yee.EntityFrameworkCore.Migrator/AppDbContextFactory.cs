using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Yee.Abstractions;
using Yee.EntityFrameworkCore.Identity;
using Yee.Extensions;

namespace Yee.EntityFrameworkCore.Migrator
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AbilityIdentityDbContext>
    {
        public AbilityIdentityDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRootOptions, RootManager>();
            IYeeModule module = new Yee.EntityFrameworkCore.Module();
            var yeeBuilder = new YeeBuilder();
            module.Build(yeeBuilder);

            YeeBuilderHandler.Go(yeeBuilder, YeeBuilderTags.AspConfigureServices, services);

            module = new Yee.EntityFrameworkCore.Npgsql.Module();
            yeeBuilder = new YeeBuilder();
            module.Build(yeeBuilder);

            YeeBuilderHandler.Go(yeeBuilder, YeeBuilderTags.AspConfigureServices, services);

            module = new Yee.EntityFrameworkCore.Identity.Module();
            yeeBuilder = new YeeBuilder();
            module.Build(yeeBuilder);

            YeeBuilderHandler.Go(yeeBuilder, YeeBuilderTags.AspConfigureServices, services);

            var provider = services.BuildServiceProvider(true);
            var scope = provider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<AbilityIdentityDbContext>();
        }
    }
}
