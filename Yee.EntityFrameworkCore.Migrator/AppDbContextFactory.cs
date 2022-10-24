using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Yee.Abstractions;
using Yee.DynamicRouters.Data;
using Yee.Extensions;
using Yee.Page;

namespace Yee.EntityFrameworkCore.Migrator
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<DynamicRouterDbContext>
    {
        public DynamicRouterDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRootOptions, RootManager>();

            LoadModule<Yee.EntityFrameworkCore.Module>(services);
            LoadModule<Yee.EntityFrameworkCore.Npgsql.Module>(services);
            LoadModule<Yee.DynamicRouters.Module>(services);
            //LoadModule<Yee.Page.Module>(services);

            var provider = services.BuildServiceProvider(true);
            var scope = provider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<DynamicRouterDbContext>();
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
