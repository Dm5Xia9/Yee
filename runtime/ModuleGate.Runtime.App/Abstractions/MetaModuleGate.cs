using Microsoft.Extensions.DependencyInjection;
using ModuleGate.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    internal class MetaModuleGate : IMetaModuleGate
    {
        private IServiceCollection _services = null;
        public IServiceCollection Services => _services;

        internal void SetServices(IServiceCollection services)
        {
            _services = services;
        }
    }
}
