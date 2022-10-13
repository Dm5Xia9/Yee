using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.MVC.Abstractions;

namespace Yee.MVC.Endpoints
{
    public class BlazorEndpoint : IYeeEndpoint
    {
        public string Id => this.GetType().Name;

        public void Next(IEndpointRouteBuilder builder)
        {
            builder.MapBlazorHub();
            builder.MapFallbackToPage("/_Host");
        }
    }
}
