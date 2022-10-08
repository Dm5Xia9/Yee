using ModuleGate.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate
{
    public class MiddlewareBuilder : LinkedList<IMiddleComponent>
    {
        public IMiddleComponent Get(string id)
        {
            return this.First(p => p.Id == id);
        }
    }
}
