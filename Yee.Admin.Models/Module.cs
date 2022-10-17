using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Abstractions;
using Yee.Admin.Defualt;
using Yee.Admin.Extensions;
using Yee.Admin.Models;
using Yee.Admin.Models.Navigations;
using Yee.Admin.Models.Pages;
using Yee.Admin.Services;
using Yee.Ant.Extensions;
using Yee.Extensions;
using Yee.Metronic.Extensions;
using Yee.Services;
using Yee.Web.Extensions;

namespace Yee.Admin.Models
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            AdminCompose buffer;
            builder
                .UseMetronic()
                .UseAntDesign()
                .AspConfigureServices(p =>
                {
                    p.AddScoped<INavPatch, PageNavPatch>();
                })
                .YeeAdminCompose(p =>
                {
                    p.AssembliesForAdminLayout.Add(typeof(ProtoModel).Assembly);
                });

        }
    }
}
