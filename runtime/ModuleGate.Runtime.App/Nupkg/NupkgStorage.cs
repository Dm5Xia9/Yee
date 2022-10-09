using ModuleGate.Abstractions;
using ModuleGate.Models;
using Newtonsoft.Json;
using NuGet.Configuration;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Nupkg
{
    public class NupkgStorage
    {
        private readonly string _mgPath;
        private readonly string _mgRootPath;
        private readonly List<MgModuleMetadata> _mgModuleMetadata;
        public NupkgStorage(NupkgOptions nupkgOptions)
        {
            var rootPath = nupkgOptions.StoragePath;

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            _mgPath = Path.Combine(rootPath, "mg.json");

            if (!File.Exists(_mgPath))
            {
                File.Create(_mgPath).Close();
                _mgModuleMetadata = new List<MgModuleMetadata>();
                File.WriteAllText(_mgPath,
                    JsonConvert.SerializeObject(_mgModuleMetadata));
            }
            else
            {
                var json = File.ReadAllText(_mgPath);
                _mgModuleMetadata =
                    JsonConvert.DeserializeObject<List<MgModuleMetadata>>(json) 
                    ?? new List<MgModuleMetadata>();
            }

            _mgRootPath = Path.Combine(rootPath, "mg_modules");

            if (!Directory.Exists(_mgRootPath))
                Directory.CreateDirectory(_mgRootPath);


        }

        public async Task<string> GetAssemblyPathFromAssemblyName(AssemblyName assemblyName, 
            INugetRepository nugetRepository)
        {
            var module = SearchFromAssemblyName(assemblyName);
            if (module == null)
            {
                using var pack = await nugetRepository.GetNupkgFromAssemblyName(assemblyName);
                if (pack == null)
                    return null;
                
                using var reader = new PackageArchiveReader(pack);
                SaveMgModule(assemblyName, reader, nugetRepository.NugetSource);
                module = SearchFromAssemblyName(assemblyName);
                if(module == null)
                    return null;
            }

            return module.Source;
        }

        private MgModuleMetadata? SearchFromAssemblyName(AssemblyName assemblyName)
        {
            return _mgModuleMetadata
                .FirstOrDefault(p => p.ModuleName == assemblyName.Name
                && p.ModuleVersion == assemblyName.Version!.ToString());
        }

        public void SaveMgModule
            (AssemblyName assemblyName, PackageReaderBase packageReaderBase, string nugetSource)
        {
            var newModules = new List<MgModuleMetadata>();
            foreach (var lib in packageReaderBase.GetLibItems())
            {
                var module = new MgModuleMetadata();
                module.InternalOther = new List<string>();
                module.ModuleName = assemblyName.Name!;
                module.ModuleVersion = assemblyName.Version!.ToString();
                module.Framework = lib.TargetFramework.ToString();
                module.NugetSource = nugetSource;
                foreach (var item in lib.Items)
                {
                    switch (Path.GetExtension(item))
                    {
                        case ".dll":
                            if (module.InternalSource != null)
                                throw new Exception("Интересно возможно ли это 1");
                            else
                                module.InternalSource = item;
                            break;
                        case ".xml":
                            if (module.InternalXml != null)
                                throw new Exception("Интересно возможно ли это 2");
                            else
                                module.InternalXml = item;
                            break;

                        default:
                            module.InternalOther.Add(item);
                            break;
                    }
                }

                newModules.Add(module);
            }

            var packetSource = Path.Combine(_mgRootPath, $"{assemblyName.Name}_{assemblyName.Version}");
            foreach(var module in newModules)
            {
                var moduleSourcePath = Path.Combine(packetSource, module.InternalSource);
                CreateAndCopyModule(moduleSourcePath, module.InternalSource, packageReaderBase);
                module.Source = moduleSourcePath;
                if(module.InternalXml != null)
                {
                    var moduleXmlPath = Path.Combine(packetSource, module.InternalXml);
                    CreateAndCopyModule(moduleXmlPath, module.InternalXml, packageReaderBase);
                    module.Xml = moduleXmlPath;
                }

                List<string> other = new List<string>();
                foreach (var otherModule in module.InternalOther)
                {
                    var moduleOtherPath = Path.Combine(packetSource, otherModule);
                    CreateAndCopyModule(moduleOtherPath, otherModule, packageReaderBase);
                    other.Add(moduleOtherPath);
                }
                module.Other = other.ToArray();
            }

            _mgModuleMetadata.AddRange(newModules);

            File.WriteAllText(_mgPath, JsonConvert.SerializeObject(_mgModuleMetadata));
        }

        private void CreateAndCopyModule(string filePath, string internalModulePath, PackageReaderBase packageReaderBase)
        {
            using (var stream = packageReaderBase.GetStream(internalModulePath))
            {
                var dirName = Path.GetDirectoryName(filePath);
                Directory.CreateDirectory(dirName);
                using var file = File.Create(filePath);
                stream.CopyTo(file);
            }
        }
    }


}
