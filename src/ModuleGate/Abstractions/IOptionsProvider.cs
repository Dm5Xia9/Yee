using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Abstractions
{
    public interface IOptionsProvider
    {
        public IConfiguration GetModuleConfiguration(Assembly assembly);
    }
}
