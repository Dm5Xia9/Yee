using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.DynamicRouters.Data;
using Yee.DynamicRouters.Middles;
using Yee.DynamicRouters.Shared;
using Yee.Extensions;
using Yee.MVC.Endpoints;
using Yee.MVC.Extensions;
using Yee.Web.Extensions;

namespace Yee.DynamicRouters
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddScoped<DynamicRouterDbContext>();
                    p.AddScoped<RouteState>();
                    //p.AddSingleton<BlazorEndpointOptions>(new BlazorEndpointOptions { Page = "/" });
                })
                .WebApp(p =>
                {
                    p.AddLayout(typeof(DynamicLayout));
                })
                .AspConfigure(p =>
                {
                    //var blazor = p.Get("MiddleBlazor");

                    //p.AddAfter(p.Find(blazor)!, new MiddleDynamicComponent());
                });
        }
    }
}
