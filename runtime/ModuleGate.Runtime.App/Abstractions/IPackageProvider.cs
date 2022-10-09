using Microsoft.AspNetCore.Hosting;
using ModuleGate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public interface IPackageProvider
    {
        public ModulePackage? Load(IWebHostEnvironment webHost, MgModuleMetadata mgModule);

    }
}
