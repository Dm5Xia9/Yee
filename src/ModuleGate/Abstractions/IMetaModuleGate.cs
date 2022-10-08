using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Abstractions
{
    public interface IMetaModuleGate
    {
        public IServiceCollection Services { get; }
    }
}
