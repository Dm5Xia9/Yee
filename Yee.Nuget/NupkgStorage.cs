using Newtonsoft.Json;
using NuGet.Packaging.Core;
using NuGet.Packaging;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Yee.Nuget.Abstractions;
using Yee.Nuget.Models;

namespace Yee.Nuget
{
    public class NupkgStorage
    {
        private readonly string _mgPath;
        private readonly string _mgRootPath;
        private readonly List<NupkgModuleMetadata> _mgModuleMetadata;

        private readonly string _dependenciesPath;
        private readonly NuGetPackageDependencies _nuGetPackageDependencies;
        public NupkgStorage(NupkgOptions nupkgOptions)
        {
            var rootPath = nupkgOptions.StoragePath;

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            _mgPath = Path.Combine(rootPath, "mg.json");
            _mgModuleMetadata = CreateOrRead<List<NupkgModuleMetadata>>(_mgPath);

            _dependenciesPath = Path.Combine(rootPath, "global-deps.json");
            _nuGetPackageDependencies = CreateOrRead<NuGetPackageDependencies>(_dependenciesPath);


            _mgRootPath = Path.Combine(rootPath, "mg_modules");

            if (!Directory.Exists(_mgRootPath))
                Directory.CreateDirectory(_mgRootPath);
        }

        private T CreateOrRead<T>(string path) where T : new()
        {
            T result;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                result = new T();
                File.WriteAllText(path,
                    JsonConvert.SerializeObject(result));
            }
            else
            {
                var json = File.ReadAllText(path);
                result =
                    JsonConvert.DeserializeObject<T>(json)
                    ?? new T();
            }

            return result;
        }

        public async Task<NupkgModuleMetadata> GetAssemblyMetadataFromAssemblyName(NugetPacket nugetPacket,
            INugetRepository nugetRepository)
        {
            var module = SearchFromAssemblyName(nugetPacket);
            if (module == null)
            {


                var pack = await nugetRepository.GetNupkg(nugetPacket);
                if (pack == null)
                {
                    var searchPacks = await nugetRepository
                        .Search(new SearchPreferences(),
                        new SearchFilter(true), nugetPacket.Id);

                    var sPack = searchPacks.FirstOrDefault(p => p.Value.Identity.Id == nugetPacket.Id);
                    if (sPack == null)
                        return null;
                    pack = await nugetRepository.GetNupkg(new NugetPacket
                    {
                        Id = sPack.Value.Identity.Id,
                        Version = sPack.Value.Identity.Version.OriginalVersion
                    });

                }

                using var reader = new PackageArchiveReader(pack);
                SaveMgModule(nugetPacket, reader, nugetRepository.NugetSource);
                module = SearchFromAssemblyName(nugetPacket);
                if (module == null)
                    return null;
            }

            return module;
        }


        public async Task<List<PackageDependency>> SearchDependency
            (NugetPacket nugetPacket, INugetRepository nugetRepository)
        {
            if (_nuGetPackageDependencies.Packages
                .Any(p => p.Packet.Id == nugetPacket.Id))
                return _nuGetPackageDependencies.Packages
                    .First(p => p.Packet.Id == nugetPacket.Id).Dependencies
                    .Select(p => new PackageDependency(p.Id,
                        new VersionRange(NuGetVersion.Parse(p.Version), originalString: p.Version)))
                    .ToList();


            var package = new NuGetPackageDependencies.Package();
            package.Packet = nugetPacket;
            List<PackageDependency> packageDependencies = new List<PackageDependency>();
            await SearchAllDependency(nugetPacket, packageDependencies, nugetRepository);
            package.Dependencies = packageDependencies
                .Select(p => new NuGetPackageDependencies.NPackageDependency
                {
                    Id = p.Id,
                    Version = p.VersionRange.OriginalString
                }).ToList();

            _nuGetPackageDependencies.Packages.Add(package);

            File.WriteAllText(_dependenciesPath,
                JsonConvert.SerializeObject(_nuGetPackageDependencies));
            return packageDependencies;
        }

        public async Task SearchAllDependency(NugetPacket nugetPacket,
            List<PackageDependency> packageDependencies, INugetRepository nugetRepository)
        {
            var deps = await nugetRepository
               .GetDependencies(nugetPacket);


            var allAssemblies = AssemblyLoadContext.All.SelectMany(p => p.Assemblies)
                .Select(p => p.GetName())
                .ToList();

            var newDeps = deps
                .Where(p =>
                    !packageDependencies.Any(z => z.Id == p.Id &&
                    z.VersionRange.OriginalString == p.VersionRange.OriginalString))
                .Where(p => !allAssemblies.Any(z => z.Name == p.Id))
                .ToList();
            if (newDeps.Any())
            {
                packageDependencies.AddRange(newDeps);
                foreach (var dependency in newDeps)
                {
                    try
                    {
                        Assembly.Load(dependency.Id);
                    }
                    catch
                    {
                        await SearchAllDependency(new NugetPacket
                        {
                            Id = dependency.Id,
                            Version = dependency.VersionRange.OriginalString
                        }, packageDependencies, nugetRepository);
                    }

                }
            }

        }


        private NupkgModuleMetadata? SearchFromAssemblyName(NugetPacket nugetPacket)
        {
            return _mgModuleMetadata
                .FirstOrDefault(p => p.ModuleName == nugetPacket.Id
                && p.ModuleVersion == nugetPacket.Version!.ToString());
        }

        public void SaveMgModule
            (NugetPacket nugetPacket, PackageReaderBase packageReaderBase, string nugetSource)
        {
            var newModules = new List<NupkgModuleMetadata>();
            foreach (var lib in packageReaderBase.GetLibItems())
            {
                var module = new NupkgModuleMetadata();
                module.InternalOther = new List<string>();
                module.ModuleName = nugetPacket.Id!;
                module.ModuleVersion = nugetPacket.Version!.ToString();
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

            var packetSource = Path.Combine(_mgRootPath, $"{nugetPacket.Id}_{nugetPacket.Version}");
            foreach (var file in packageReaderBase.GetFiles())
            {
                var moduleOtherPath = Path.Combine(packetSource, file);
                CreateAndCopyModule(moduleOtherPath, file, packageReaderBase);
            }

            foreach (var module in newModules)
            {
                var moduleSourcePath = Path.Combine(packetSource, module.InternalSource);
                module.Source = moduleSourcePath;

                if (module.InternalXml != null)
                {
                    var moduleXmlPath = Path.Combine(packetSource, module.InternalXml);
                    module.Xml = moduleXmlPath;
                }
                List<string> other = new List<string>();
                foreach (var otherModule in module.InternalOther)
                {
                    var moduleOtherPath = Path.Combine(packetSource, otherModule);
                    other.Add(moduleOtherPath);
                }
                module.Other = other.ToArray();

                var webAssets = Path.Combine(packetSource, "staticwebassets");

                if (Directory.Exists(webAssets))
                {
                    module.StaticWebAssetsPath = webAssets;
                }


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
