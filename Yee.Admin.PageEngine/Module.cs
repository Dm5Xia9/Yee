using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Abstractions;
using Yee.Admin.Extensions;
using Yee.Admin.PageEngine.Shared;
using Yee.Ant.Extensions;
using Yee.Extensions;
using Yee.Section.Base;
using Yee.Web.Extensions;

namespace Yee.Admin.PageEngine
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
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
                .WebApp(p =>
                {
                    //p.AddRouter(typeof(App));
                    p.AddLayout(typeof(PageEngineLayout));
                });
        }
    }
}
