using ModuleGate.Runtime.App.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.PackageProviders
{
    public class NupkgPackageProvider 
    {
        public string FileExtension => ".nupkg";    

        public ModulePackage Load(string path, List<string> allPathes)
        {
            throw new NotImplementedException();
        }


    }
}
