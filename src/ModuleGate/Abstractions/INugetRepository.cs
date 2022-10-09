using ModuleGate.Models;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace ModuleGate.Abstractions
{
    public interface INugetRepository
    {
        public string NugetSource { get; }
        public Task<Stream?> GetNupkg(NugetPacket nugetPacket);
        public Task<IEnumerable<PackageMetadata>> Search(SearchPreferences searchPreferences, SearchFilter searchFilter, string searchTerm);
        public Task<IEnumerable<PackageDependency>> GetDependencies(NugetPacket nugetPacket);    }
}
