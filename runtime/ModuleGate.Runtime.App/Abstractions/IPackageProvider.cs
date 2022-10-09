using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public interface IPackageProvider
    {
        public string FileExtension { get; }
        public ModulePackage Load(string path, Action next);

    }
}
