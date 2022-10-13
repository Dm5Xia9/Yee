using Yee.Abstractions;
using Yee.Nuget.Models;
using Yee.Nuget;
using Yee.Runtime.Builder.Abstractions;
using System.Runtime.Loader;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Yee.Runtime.Builder.Helpers;

namespace Yee.Runtime.YeeProviders
{
    public class NupkgYeeProvider : IYeeProvider<NupkgModule>
    {
        private readonly YeeModuleStorage _yeeModuleStorage;
        private readonly AssemblyLoadContext _context;

        private readonly NupkgStorage _nupkgStorage;
        private readonly CombineNugetRepository _combineNugetRepository;
        private AssemblyName CurrentAssemblyName;
        private readonly IWebHostEnvironment _webHost;
        private readonly List<NupkgModule> _cache = new List<NupkgModule>();

        public NupkgYeeProvider(NupkgOptions options, NupkgStorage storage, YeeModuleStorage yeeModuleStorage, IWebHostEnvironment webHost)
        {
            _yeeModuleStorage = yeeModuleStorage;
            _nupkgStorage = storage;
            _context = new AssemblyLoadContext("nupkg", true);
            _context.Resolving += _context_Resolving;

            _combineNugetRepository =
                new CombineNugetRepository(
                    options.Sources.Select(p => new NugetRepository(p)).ToArray());
            _webHost = webHost;
        }


        public IEnumerable<BaseYeeModule> Resolve()
        {
            return _yeeModuleStorage.GetAllModules()
                .Select(p => LoadSingleModule(p)).ToList();
        }

        private System.Reflection.Assembly? _context_Resolving(AssemblyLoadContext arg1, System.Reflection.AssemblyName arg2)
        {
            return Task.Run(async () =>
            {
                var realVersion = await GetRealVersion(arg2);
                var assemblyPath = _nupkgStorage
                    .GetAssemblyMetadataFromAssemblyName(new NugetPacket
                    {
                        Id = arg2.Name,
                        Version = realVersion
                    }, _combineNugetRepository)
                    .Result;

                if (assemblyPath == null)
                    return null;


                return GetAssemblyByMetadata(assemblyPath);
            }).Result;
        }

        private async Task<string> GetRealVersion(AssemblyName assemblyName)
        {
            var all = await _nupkgStorage.SearchDependency(new NugetPacket
            {
                Id = CurrentAssemblyName.Name!,
                Version = CurrentAssemblyName.Version!.ToString()
            }, _combineNugetRepository);

            var lib = all.FirstOrDefault(p => p.Id == assemblyName.Name);
            if (lib == null)
                throw new Exception();

            return lib.VersionRange.OriginalString;
        }

        private Assembly GetAssemblyByMetadata(NupkgModuleMetadata mgModuleMetadata)
        {
            if (mgModuleMetadata.StaticWebAssetsPath != null)
            {
                _webHost.WebRootFileProvider =
                    new CompositeFileProvider(_webHost.WebRootFileProvider,
                    new PhysicalFileProvider(mgModuleMetadata.StaticWebAssetsPath));
            }

            return _context.LoadFromAssemblyPath(mgModuleMetadata.Source);
        }

        private NupkgModule LoadSingleModule(NupkgModuleMetadata mgModule)
        {
            Assembly assembly;
            if (mgModule.Assembly == null)
            {
                mgModule = ResolveFromMetadata(mgModule);

                assembly = GetAssemblyByMetadata(mgModule);

                if (mgModule.StaticWebAssetsPath != null)
                {
                    _webHost.WebRootFileProvider =
                        new CompositeFileProvider(_webHost.WebRootFileProvider,
                        new PhysicalFileProvider(mgModule.StaticWebAssetsPath));
                }

                assembly = _context.LoadFromAssemblyPath(mgModule.Source);

            }
            else
            {
                assembly = mgModule.Assembly;
            }

            CurrentAssemblyName = assembly.GetName();

            var packet = LoadFromAssembly(assembly);
            return packet.Result;
        }

        private NupkgModuleMetadata ResolveFromMetadata(NupkgModuleMetadata input)
        {
            if (string.IsNullOrEmpty(input.Source))
            {
                input = ResolveAssemblyPathModule(input.NugetSource,
                    new NugetPacket
                    {
                        Id = input.ModuleName,
                        Version = input.ModuleVersion
                    }).Result;
            }


            if (string.IsNullOrEmpty(input.Source))
            {
                throw new Exception("Не могу найти пакет");
            }
            return input;

        }

        private async Task<NupkgModuleMetadata> ResolveAssemblyPathModule(string source, NugetPacket assemblyName)
        {
            return await _nupkgStorage
                .GetAssemblyMetadataFromAssemblyName(assemblyName,
                    new NugetRepository(source));
        }

        private async Task<NupkgModule> LoadFromAssembly(Assembly assembly, bool resolveStaticAssets = false)
        {
            if (_cache.Any(p => p.Assembly == assembly))
                return _cache
                    .First(p => p.Assembly == assembly);


            if (resolveStaticAssets)
            {
                var realVersion = await GetRealVersion(assembly.GetName());

                var mgModule = await _nupkgStorage
                    .GetAssemblyMetadataFromAssemblyName(new NugetPacket
                    {
                        Id = assembly.GetName().Name,
                        Version = realVersion,
                    }, _combineNugetRepository);

                if (mgModule.StaticWebAssetsPath != null)
                {
                    _webHost.WebRootFileProvider =
                        new CompositeFileProvider(_webHost.WebRootFileProvider,
                        new PhysicalFileProvider(mgModule.StaticWebAssetsPath));
                }
            }

            NupkgModule depNodeAssembly = new NupkgModule();
            depNodeAssembly.Assembly = assembly;
            depNodeAssembly.YeeModule = YeeAssemblyHelpers.CreateYeeModule(assembly);
            var builder = new YeeBuilder();
            depNodeAssembly.YeeModule.Build(builder);


            var appDeps = YeeAssemblyHelpers.GetDepsFromModule(depNodeAssembly);

            depNodeAssembly.Deps = new List<BaseYeeModule>();
            var deps = assembly.GetReferencedAssemblies();

            _cache.Add(depNodeAssembly);
            foreach (var dep in deps.Where(p => !p.Name!.StartsWith("System.")))
            {
                Assembly depAs;
                try
                {
                    if (!_context.Assemblies.Any(p => p.GetName().Name == dep.Name))
                    {
                        depAs = _context.LoadFromAssemblyName(dep);

                    }
                    else
                    {
                        depAs = _context.Assemblies.First(p => p.GetName().Name == dep.Name);
                    }

                }
                catch (FileNotFoundException ex)
                {
                    continue;
                }

                if (YeeAssemblyHelpers.IsYeeFromAssembly(depAs) || appDeps.Contains(depAs))
                {
                    depNodeAssembly.Deps.Add(await LoadFromAssembly(depAs, true));
                }
            }

            return depNodeAssembly;
        }

    }

    public class NupkgModule : BaseYeeModule
    {

    }
}
