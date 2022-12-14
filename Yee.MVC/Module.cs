using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.MVC.Endpoints;
using Yee.MVC.Middlewares;
using Yee.Services;
using Yee.Web.Extensions;
using Yee.Web.Middlewares;

namespace Yee.MVC
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            YeeEndpoints buffer = null;
            builder
                .AspConfigureServices((p, modules) =>
                {
                    var builder = p.AddMvc();

                    foreach(var module in modules.ToAlignmentTrees())
                    {
                        builder
                            .AddApplicationPart(module.Assembly)
                            .AddControllersAsServices();
                    }

                    p.AddControllers();
                    p.AddSingleton<YeeEndpoints>();
                    p.AddSingleton<BlazorEndpointOptions>();
                    p.AddScoped<MyTransformer>();
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    var options = p.GetRequiredService<IEnumerable<BlazorEndpointOptions>>();

                    buffer = p.GetRequiredService<YeeEndpoints>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyAspEndpoints, buffer);
                    buffer.AddLast(new BlazorEndpoint(options));
                })
                .AspConfigure(p =>
                {
                    if (buffer == null)
                        throw null;

                    var blazorMiddle = p.Get("MiddleBlazor");
                    p.Find(blazorMiddle)!.Value = 
                        new EmptyMiddle("MiddleBlazor");

                    p.AddLast(new EndpointMiddleComponent(buffer));
                });
        }

        public class MyTransformer : DynamicRouteValueTransformer
        {
            public MyTransformer()
            {

            }

            public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext
                   httpContext, RouteValueDictionary values)
            {
                return new RouteValueDictionary()
{
                    //we need to use a / to prefix the page name here
                    { "page", "/admin" },
                    { "id", "123" }
                };
                //return await Task.Run(() =>
                //{
                //    var rng = new Random();
                //    if (rng.NextDouble() < 0.5)
                //    {
                //        values["page"] = "/admin";
                //    }
                //    else
                //    {
                //        values["page"] = "/admin";
                //    }


                //    return values;
                //});
            }
        }
    }
}
