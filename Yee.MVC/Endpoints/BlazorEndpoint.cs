using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.MVC.Abstractions;
using Yee.Services;

namespace Yee.MVC.Endpoints
{
    public class BlazorEndpoint : IYeeEndpoint
    {
        private readonly IEnumerable<BlazorEndpointOptions> _options;

        public BlazorEndpoint(IEnumerable<BlazorEndpointOptions> options)
        {
            _options = options;
        }

        public string Id => this.GetType().Name;

        public void Next(IEndpointRouteBuilder builder)
        {
            //var build = builder.MapFallback(context => 
            //Task.CompletedTask);
            //build.Add(b =>
            //{

            //    b.RequestDelegate = async p =>
            //    {
            //        p.Response.StatusCode = 403;
            //        await p.Response.WriteAsync("Динамическая страница");
            //    };
            //});

            builder.MapBlazorHub();
            foreach(var option in _options)
            {
                builder.MapFallbackToPage(option.Page);
            }
        }
    }

    public class BlazorEndpointOptions
    {
        public string Pattern { get; set; }
        public string Page { get; set; }
            = "/_Host";
    }
}
