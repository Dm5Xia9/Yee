using Microsoft.AspNetCore.Hosting;
using ModuleGate.Models;
using ModuleGate.Runtime.App.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App
{
    public class PackageLoader
    {
        private IEnumerable<IPackageProvider> _packageProviders;

        public PackageLoader(IEnumerable<IPackageProvider> packageProviders)
        {
            _packageProviders = packageProviders;
        }

        public ModulePackage Load(IWebHostEnvironment webHost, MgModuleMetadata mgModule)
        {
            foreach(var provider in _packageProviders)
            {
                var pack = provider.Load(webHost, mgModule);
                if (pack != null)
                    return pack;
            }

            return null;
        }
    }
}
