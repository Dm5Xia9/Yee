using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public interface IModuleStorage
    {
        public List<ModulePackage> Load(IWebHostEnvironment webHost);
    }
}
