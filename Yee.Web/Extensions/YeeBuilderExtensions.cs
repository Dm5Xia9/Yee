using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Web.Models;

namespace Yee.Web.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string TagAspConfigure = "AspConfigure";

        public static YeeBuilder AspConfigure(this YeeBuilder builder,
            Action<MiddlewareBuilder> action)
        {
            builder.Add(TagAspConfigure, p =>
            {
                action((MiddlewareBuilder)p);
            });

            return builder;
        }

        public const string TagWebApp = "WebApp";

        public static YeeBuilder WebApp(this YeeBuilder builder,
            Action<WebAppBuilder> action)
        {
            builder.Add(TagWebApp, p =>
            {
                action((WebAppBuilder)p);
            });

            return builder;
        }
    }
}
