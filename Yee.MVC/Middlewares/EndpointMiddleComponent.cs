using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Web.Middlewares;
using static Yee.MVC.Module;

namespace Yee.MVC.Middlewares
{
    public class EndpointMiddleComponent : IMiddleComponent
    {
        private readonly YeeEndpoints _yeeEndpoints;

        public EndpointMiddleComponent(YeeEndpoints yeeEndpoints)
        {
            _yeeEndpoints = yeeEndpoints;
        }

        public string Id => this.GetType().Name;

        public void Next(WebApplication app)
        {

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //    endpoints.MapDynamicPageRoute<MyTransformer>("{**id}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDynamicPageRoute<MyTransformer>("{**id}");
                foreach (var endpoint in _yeeEndpoints)
                {
                    endpoint.Next(endpoints);
                }
            });
        }
    }
}
