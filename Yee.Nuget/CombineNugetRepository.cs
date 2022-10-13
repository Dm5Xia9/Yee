using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using Yee.Nuget.Abstractions;
using Yee.Nuget.Models;

namespace Yee.Nuget
{
    public class CombineNugetRepository : INugetRepository
    {
        private readonly INugetRepository[] _nugetRepositories;
        private object _lock = new object();
        public CombineNugetRepository(params INugetRepository[] nugetRepositories)
        {
            _nugetRepositories = nugetRepositories;
        }

        public string NugetSource => null;

        public async Task<Stream?> GetNupkg(NugetPacket nugetPacket)
        {
            foreach (var nuget in _nugetRepositories)
            {
                var result = await nuget.GetNupkg(nugetPacket);

                if (result != null)
                    return result;
            }

            return null;
        }

        public async Task<IEnumerable<PackageDependency>> GetDependencies(NugetPacket nugetPacket)
        {
            var stream = await GetNupkg(nugetPacket);
            if (stream == null)
                return null;

            using var packageReader = new PackageArchiveReader(stream);
            var nuspecReader = await packageReader
                .GetNuspecReaderAsync(CancellationToken.None);

            var deps = nuspecReader.GetDependencyGroups();
            if (!deps.Any())
                return new List<PackageDependency>();

            var net6depns = nuspecReader.GetDependencyGroups()
                .First(p => DefaultCompatibilityProvider
                .Instance.IsCompatible(NuGetFramework.Parse("net6.0"), p.TargetFramework));

            return net6depns.Packages;
        }

        public async Task<IEnumerable<PackageMetadata>> Search(SearchPreferences searchPreferences,
            SearchFilter searchFilter, string searchTerm)
        {
            List<PackageMetadata> list = new List<PackageMetadata>();

            var reps = _nugetRepositories.AsEnumerable();
            if (searchPreferences.NuGetSource != null)
            {
                reps = _nugetRepositories
                    .Where(p => p.NugetSource == searchPreferences.NuGetSource);
            }
            foreach (var p in reps)
            {
                var result = await p.Search(searchPreferences, searchFilter, searchTerm);

                lock (_lock)
                {
                    list.AddRange(result);
                }

            }

            return list;
        }
    }

}
