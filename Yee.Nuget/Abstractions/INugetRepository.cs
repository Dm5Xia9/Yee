using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Nuget.Models;

namespace Yee.Nuget.Abstractions
{
    public interface INugetRepository
    {
        public string NugetSource { get; }
        public Task Load();
        public Task<Stream?> GetNupkg(NugetPacket nugetPacket);
        public Task<IEnumerable<PackageMetadata>> Search(SearchPreferences searchPreferences, SearchFilter searchFilter, string searchTerm);
        public Task<IEnumerable<PackageDependency>> GetDependencies(NugetPacket nugetPacket);
    }
}
