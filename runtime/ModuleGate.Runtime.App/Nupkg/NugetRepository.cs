using NuGet.Common;
using NuGet.Configuration;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Nupkg
{
    public class NugetRepository : INugetRepository
    {
        private readonly SourceCacheContext _cache;
        private readonly ILogger _logger;
        private CancellationToken _cancellationToken;
        private readonly SourceRepository _sourceRepository;
        private readonly FindPackageByIdResource _findPackageByIdResource;
        private readonly PackageSearchResource _packageSearchResource;
        private readonly string _source;
        public NugetRepository(string source)
        {
            _source = source;
            _logger = NullLogger.Instance;
            _cancellationToken = CancellationToken.None;
            _cache = new SourceCacheContext();
            _sourceRepository = Repository.Factory.GetCoreV3(source);
            _findPackageByIdResource = 
                _sourceRepository.GetResource<FindPackageByIdResource>();
            _packageSearchResource =
                _sourceRepository.GetResource<PackageSearchResource>();
        }

        public async Task<Stream?> GetNupkgFromAssemblyName(AssemblyName assemblyName)
        {
            MemoryStream packageStream = new MemoryStream();
            var result = await _findPackageByIdResource.CopyNupkgToStreamAsync(
                assemblyName.Name,
                new NuGetVersion(assemblyName.Version),
                packageStream,
                _cache,
                _logger,
                _cancellationToken);

            if (result == false)
                return null;

            return packageStream;
        }

        public async Task<IEnumerable<PackageMetadata>> Search(SearchFilter searchFilter, string searchTerm)
        {
            var results = await _packageSearchResource.SearchAsync(
                searchTerm,
                searchFilter,
                skip: 0,
                take: 10,
                NullLogger.Instance,
                CancellationToken.None);

            return results.Select(p => new PackageMetadata(_source, p));
        }
    }

    public class PackageMetadata
    {
        public PackageMetadata(string source, IPackageSearchMetadata value)
        {
            Source = source;
            Value = value;
        }

        public string Source { get; }
        public IPackageSearchMetadata Value { get; }
    }

    public class CombineNugetRepository : INugetRepository
    {
        private readonly INugetRepository[] _nugetRepositories;
        private object _lock = new object();
        public CombineNugetRepository(params INugetRepository[] nugetRepositories)
        {
            _nugetRepositories = nugetRepositories;
        }

        public async Task<Stream?> GetNupkgFromAssemblyName(AssemblyName assemblyName)
        {
            foreach(var nuget in _nugetRepositories)
            {
                var result = await nuget.GetNupkgFromAssemblyName(assemblyName);

                if (result != null)
                    return result;
            }

            return null;
        }

        public async Task<IEnumerable<PackageMetadata>> Search(SearchFilter searchFilter, string searchTerm)
        {
            List<PackageMetadata> list = new List<PackageMetadata>();

            Parallel.ForEach(_nugetRepositories, async p =>
            {
                var result = await p.Search(searchFilter, searchTerm);

                lock (_lock)
                {
                    list.AddRange(result);
                }
            });

            return list;
        }
    }

    public interface INugetRepository
    {
        public Task<Stream?> GetNupkgFromAssemblyName(AssemblyName assemblyName);
        public Task<IEnumerable<PackageMetadata>> Search(SearchFilter searchFilter, string searchTerm);

    }
}
