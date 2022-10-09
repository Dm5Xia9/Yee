using ModuleGate.Models;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace ModuleGate.Abstractions
{
    public interface INugetRepository
    {
        public string NugetSource { get; }
        public Task<Stream?> GetNupkgFromAssemblyName(AssemblyName assemblyName);
        public Task<IEnumerable<PackageMetadata>> Search(SearchPreferences searchPreferences, SearchFilter searchFilter, string searchTerm);

    }
}
