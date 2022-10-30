using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Yee.Abstractions;
using Yee.EntityFrameworkCore.Identity;
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

            LoadModule<Yee.EntityFrameworkCore.Module>(services);
            LoadModule<Yee.EntityFrameworkCore.Npgsql.Module>(services);
            //LoadModule<Yee.DynamicRouters.Module>(services);
            LoadModule<Yee.Page.Module>(services);
            //LoadModule<Yee.EntityFrameworkCore.Identity.Module>(services);

            var provider = services.BuildServiceProvider(true);
            var scope = provider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<PageDbContext>();
        }

        public void LoadModule<T>(IServiceCollection services) where T : IYeeModule, new()
        {
            IYeeModule module = new T();
            var yeeBuilder = new YeeBuilder();
            module.Build(yeeBuilder);

            YeeBuilderHandler.Go(yeeBuilder, YeeBuilderTags.AspConfigureServices, services);
        }
    }
}
