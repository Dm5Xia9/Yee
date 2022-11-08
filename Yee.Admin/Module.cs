using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Abstractions;
using Yee.Admin.Defualt;
using Yee.Admin.Extensions;
using Yee.Admin.Navigations;
using Yee.Admin.Pages;
using Yee.Admin.SectionHandlers;
using Yee.Admin.Services;
using Yee.Admin.Shared;
using Yee.Ant.Extensions;
using Yee.Extensions;
using Yee.FileStorage.Services;
using Yee.Metronic.Extensions;
using Yee.Section.Base;
using Yee.Section.Extensions;
using Yee.Services;
using Yee.Web.Extensions;

namespace Yee.Admin
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            IServiceScopeFactory serviceScopeFactory = null;
            AdminCompose buffer;
            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<AdminCompose>();
                    p.AddScoped<IUserService, UserService>();
                    p.AddScoped<IRoleService, RoleService>();
                    p.AddScoped<INavPatch, PageNavPatch>();
                    p.AddScoped<RouteState>();
                    p.AddSingleton<FileStorageService>();
                })
                .YeeAdminCompose(p =>
                {
                    p.Navigations.AddRange(DefualtNavigations.Value);
                })
                .UseMetronic()
                .UseAntDesign()
                .WebApp(p =>
                {
                    p.AddHead(typeof(HeadApp));
                    p.AddHead(typeof(PageEngineHead));
                    p.AddLayout(typeof(AdminLayout));

                    //p.AddLayout(typeof(PageEngineLayout));

                    using var scope = serviceScopeFactory.CreateScope();

                    var routeState = scope.ServiceProvider.GetRequiredService<RouteState>();
                    p.NotFoundBuilder.Use(n =>
                    {
                        var page = routeState.GetCurrent(n);
                        if (page == null)
                            return null;


                        return typeof(DynamicPage);
                    });
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<AdminCompose>();
                    modules.HandlersFromId(Extensions.YeeBuildExtensions.KeyYeeAdminCompose, buffer);

                    serviceScopeFactory = p.GetRequiredService<IServiceScopeFactory>();

                    var webHost = p.GetRequiredService<IWebHostEnvironment>();
                    var collection = p.GetRequiredService<FileStorageCollection>();
                    var storage = p.GetRequiredService<FileStorageService>();

                    webHost.WebRootFileProvider =
                        new CompositeFileProvider(webHost.WebRootFileProvider,
                        new PhysicalFileProvider(storage.PhysicalPath));

                    collection.Add(storage);
                })
                .YeeSections(p =>
                {
                    p.AddPrototype<ProtoLink, RouteLinkProtoHandler>();
                });


        }
    }
}
