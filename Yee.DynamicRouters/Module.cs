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

                })
                .AspConfigure(p =>
                {
                    
                }).WebApp(p =>
                {
                    p.AddLayout(typeof(DynamicLayout));
                });
        }
    }
}
