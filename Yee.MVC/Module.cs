using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<YeeEndpoints>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyAspEndpoints, buffer);

                    buffer.AddLast(new BlazorEndpoint());
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
    }
}
