using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Web.Middlewares;

namespace Yee.Web
{
    public class MiddlewareBuilder : LinkedList<IMiddleComponent>
    {
        public MiddlewareBuilder(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; private set; }
        public IMiddleComponent Get(string id)
        {
            return this.First(p => p.Id == id);
        }
    }
}
