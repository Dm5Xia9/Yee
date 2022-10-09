using NuGet.Packaging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Models
{
    public class NuGetPackageDependencies
    {
        public NuGetPackageDependencies()
        {
            Packages = new List<Package>();
        }

        public List<Package> Packages { get; set; }
        public class Package
        {
            public NugetPacket Packet { get; set; }
            public List<NPackageDependency> Dependencies { get; set; }
        }

        public class NPackageDependency
        {
            public string Id { get; set; }
            public string Version { get; set; }
        }
    }

}
