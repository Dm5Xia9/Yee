using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Abstractions;
using Yee.Admin.Extensions;
using Yee.Admin.PageEngine.Pages;
using Yee.Admin.PageEngine.SectionHandlers;
using Yee.Admin.PageEngine.Services;
using Yee.Admin.PageEngine.Shared;
using Yee.Ant.Extensions;
using Yee.Extensions;
using Yee.Section.Base;
using Yee.Section.Extensions;
using Yee.Web.Extensions;

namespace Yee.Admin.PageEngine
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            IServiceScopeFactory serviceScopeFactory = null;

            builder
                .AspConfigureServices(p =>
                {
                    p.AddScoped<RouteState>();
                })
                .UseAntDesign()
                .YeeAdminCompose(p =>
                {
                    p.Navigations.Add(new NavMenuItem
                    {
                        Title = "Создать страницу",
                        Link = "/admin/pageEngine"
                    });
                    //p.AssembliesForAdminLayout.Add(typeof(App).Assembly);
                })
                .AspPostBuild(p =>
                {
                    serviceScopeFactory = p.GetRequiredService<IServiceScopeFactory>();
                })
                .WebApp(p =>
                {
                    //p.AddRouter(typeof(App));
                    p.AddLayout(typeof(PageEngineLayout));

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
                .YeeSections(p =>
                {
                    p.AddPrototype<ProtoLink, RouteLinkProtoHandler>();
                });
        }
    }
}
