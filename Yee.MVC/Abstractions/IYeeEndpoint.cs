using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.MVC.Abstractions
{
    public interface IYeeEndpoint
    {
        public string Id { get; }
        public void Next(IEndpointRouteBuilder builder);
    }
}
