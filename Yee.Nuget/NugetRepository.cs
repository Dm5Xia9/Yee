using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Nuget.Abstractions;
using Yee.Nuget.Models;

namespace Yee.Nuget
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

        public string NugetSource => _source;

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

        public async Task<Stream?> GetNupkg(NugetPacket nugetPacket)
        {
            MemoryStream packageStream = new MemoryStream();
            var result = await _findPackageByIdResource.CopyNupkgToStreamAsync(
                nugetPacket.Id,
                new NuGetVersion(nugetPacket.Version),
                packageStream,
                _cache,
                _logger,
                _cancellationToken);

            if (result == false)
                return null;

            return packageStream;
        }


        public Task<IEnumerable<PackageDependency>> GetDependencies(NugetPacket nugetPacket)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PackageMetadata>> Search(SearchPreferences searchPreferences, SearchFilter searchFilter, string searchTerm)
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

}
