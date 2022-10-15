using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Page;

namespace Yee.EntityFrameworkCore.Migrator
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<PageDbContext>
    {
        public PageDbContext CreateDbContext(string[] args)
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

            module = new Yee.Page.Module();
            yeeBuilder = new YeeBuilder();
            module.Build(yeeBuilder);

            YeeBuilderHandler.Go(yeeBuilder, YeeBuilderTags.AspConfigureServices, services);

            var provider = services.BuildServiceProvider(true);
            var scope = provider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<PageDbContext>();
        }
    }
}
