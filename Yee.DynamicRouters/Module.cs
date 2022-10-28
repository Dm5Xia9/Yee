using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.DynamicRouters.Data;
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
                    p.AddScoped<MyTransformer>();
                    //p.AddSingleton<BlazorEndpointOptions>(new BlazorEndpointOptions { Page = "/" });
                })
                .WebApp(p =>
                {
                    p.AddLayout(typeof(DynamicLayout));
                });
        }
    }

    public class MyTransformer : DynamicRouteValueTransformer
    {
        public MyTransformer()
        {

        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext
               httpContext, RouteValueDictionary values)
        {
            return await Task.Run(() =>
            {
                var rng = new Random();
                if (rng.NextDouble() < 0.5)
                {
                    values["page"] = "/admin";
                }
                else
                {
                    values["page"] = "/admin";
                }


                return values;
            });
        }
    }
}
