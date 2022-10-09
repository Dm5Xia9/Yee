using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate
{
    public abstract class ModuleStartup
    {
        public virtual void Deps(List<Assembly> assemblies)
        {

        }
        public virtual void ConfigureBuilder(WebApplicationBuilder builder)
        {

        }
        public virtual void ConfigureServices(IServiceCollection services)
        {

        }

        public virtual void Configure(MiddlewareBuilder middles)
        {

        }

        public virtual void Build(IServiceProvider provider)
        {

        }

        public virtual void Finish(IServiceProvider provider)
        {

        }
    }
}
