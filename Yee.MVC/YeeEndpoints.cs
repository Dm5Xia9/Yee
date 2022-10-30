using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.MVC.Abstractions;

namespace Yee.MVC
{
    public class YeeEndpoints : LinkedList<IYeeEndpoint>
    {
        public YeeEndpoints AddLast(string name, Action<IEndpointRouteBuilder> action)
        {
            this.AddLast(new DefualtEndpoin(action, name));
            return this;
        }

        public YeeEndpoints AddLastArea(string name, string pattern)
        {
            AddLast(name, p =>
            {
                p.MapAreaControllerRoute(
                    name: name,
                    areaName: name,
                    pattern: pattern);
            });

            return this;
        }
    }


    public class DefualtEndpoin : IYeeEndpoint
    {
        private readonly Action<IEndpointRouteBuilder> _action;
        private readonly string _name;

        public DefualtEndpoin(Action<IEndpointRouteBuilder> action, string name)
        {
            _action = action;
            _name = name;
        }

        public string Id => _name;

        public void Next(IEndpointRouteBuilder builder)
        {
            _action(builder);
        }
    }
}
