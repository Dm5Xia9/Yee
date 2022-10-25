using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            builder.Add(b =>
            {

                b.RequestDelegate = async p =>
                {
                    p.Response.StatusCode = 403;
                    await p.Response.WriteAsync("Динамическая страница");
                };
            });
        }
    }
}
