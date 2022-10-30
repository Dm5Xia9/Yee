using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Defualt;
using Yee.Admin.Extensions;
using Yee.Admin.Services;
using Yee.Admin.Shared;
using Yee.Ant.Extensions;
using Yee.Extensions;
using Yee.Metronic.Extensions;
using Yee.Services;
using Yee.Web.Extensions;

namespace Yee.Admin
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            AdminCompose buffer;
            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<AdminCompose>();
                    p.AddScoped<IUserService, UserService>();
                    p.AddScoped<IRoleService, RoleService>();
                })
                .YeeAdminCompose(p =>
                {
                    p.Navigations.AddRange(DefualtNavigations.Value);
                })
                .UseMetronic()
                .UseAntDesign()
                .WebApp(p =>
                {
                    //p.AddRouter(typeof(App));
                    p.AddLayout(typeof(AdminLayout));
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<AdminCompose>();
                    modules.HandlersFromId(Extensions.YeeBuildExtensions.KeyYeeAdminCompose, buffer);
                });


        }
    }
}
