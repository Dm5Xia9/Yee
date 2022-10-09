using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ModuleGate.Abstractions;
using ModuleGate.Runtime.App.Abstractions;
using ModuleGate.Runtime.App.Models;
using ModuleGate.Services;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Nupkg
{
    public class NupkgModuleStorage : IModuleStorage
    {
        private readonly ModuleGateStorage _moduleGateStorage;
        private readonly PackageLoader _packageLoader;
        private readonly StarterOptions _starterOptions;
        public NupkgModuleStorage(ModuleGateStorage moduleGateStorage, PackageLoader packageLoader, StarterOptions starterOptions)
        {
            _moduleGateStorage = moduleGateStorage;
            _packageLoader = packageLoader;
            _starterOptions = starterOptions;
        }


        public List<ModulePackage> Load(IWebHostEnvironment webHost)
        {
            var currentModules = _moduleGateStorage.GetAllModules();
            if (!currentModules.Any())
                return new List<ModulePackage>()
                {
                    _packageLoader.Load(webHost, _starterOptions)
                };

            List<ModulePackage> packages = new List<ModulePackage>();

            foreach (var module in currentModules)
                packages.Add(_packageLoader.Load(webHost, module));

            return packages;
        }
    }


    
}
