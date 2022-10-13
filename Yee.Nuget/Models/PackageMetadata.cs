using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Nuget.Models
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
