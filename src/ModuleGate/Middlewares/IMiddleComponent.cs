using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Middlewares
{
    public interface IMiddleComponent
    {
        public string Id { get; }
        public void Next(WebApplication app);
    }
}
