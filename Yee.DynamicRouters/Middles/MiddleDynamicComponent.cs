using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Web.Middlewares;

namespace Yee.DynamicRouters.Middles
{
    public class MiddleDynamicComponent : IMiddleComponent
    {
        public string Id => this.GetType().Name;

        public void Next(WebApplication app)
        {
            var builder = app.MapFallback(context => Task.CompletedTask);
            IActionInvokerFactory? invokerFactory = null;

            builder.Add(b =>
            {
                //b.Metadata.Add();

                b.RequestDelegate = async context =>
                {
                    var ev = context.GetEndpoint();
                    var invokerFactory = context.RequestServices.GetRequiredService<IActionDescriptorCollectionProvider>();

                    Console.WriteLine();
                    //var endpoint = context.GetEndpoint()!;

                    //PageActionDescriptor
                    //var routeData = new RouteData();
                    //routeData.PushState(router: null, context.Request.RouteValues, null);

                    //// Don't close over the ActionDescriptor, that's not valid for pages.
                    //var action = endpoint.Metadata.GetMetadata<ActionDescriptor>()!;
                    //var actionContext = new ActionContext(context, routeData, action);

                    //if (invokerFactory == null)
                    //{
                    //    invokerFactory = context.RequestServices.GetRequiredService<IActionInvokerFactory>();
                    //}

                    //var invoker = invokerFactory.CreateInvoker(actionContext);
                    //var f = invoker!.InvokeAsync();
                    //return f;
                    //var meta = p.GetEndpoint();
                    //var ap = app;
                    //Console.WriteLine(ap);
                    ////PageActionDescriptor
                    //var ff = p.RequestServices.GetRequiredService<IActionInvokerFactory>();
                    ////p.Des
                    //p.Response.StatusCode = 200;
                    //var src = "https://localhost:7062/admin";
                    //await p.Response.WriteAsync($"<html><head></head><body style=\"margin: 0;\"><iframe src=\"{src}\" style=\"width: 100%;height: 100%;border: 0;\"></iframe></body></html>");
                };
            });
        }
    }
}

//<iframe src="banner.html" width="468" height="60" align="left">Ваш браузер не поддерживает плавающие фреймы!</iframe>
//<html><head></head><body style="margin: 0;"><iframe src="" style="width: 100%;height: 100%;border: 0;"></iframe></body></html>