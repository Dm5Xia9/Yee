using NuGet.Protocol.Core.Types;

namespace ModuleGate.Models
{
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
}
