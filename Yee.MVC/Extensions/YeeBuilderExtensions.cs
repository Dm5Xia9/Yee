using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Web;

namespace Yee.MVC.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string KeyAspEndpoints = "AspEndpoints";

        public static YeeBuilder AspEndpoints(this YeeBuilder builder,
            Action<YeeEndpoints> action)
        {
            builder.Add(KeyAspEndpoints, p =>
            {
                action((YeeEndpoints)p);
            });

            return builder;
        }

        public const string KeyBlazorEndpoint = "BlazorEndpoint";

        public static YeeBuilder BlazorEndpoint(this YeeBuilder builder,
            Action<IEndpointRouteBuilder> action)
        {
            builder.Add(KeyBlazorEndpoint, p =>
            {
                action((IEndpointRouteBuilder)p);
            });

            return builder;
        }

    }
}
