using ModuleGate.Runtime.App.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App
{
    public class PackageLoader
    {
        private IEnumerable<IPackageProvider> _packageProviders;

        public PackageLoader(IEnumerable<IPackageProvider> packageProviders)
        {
            _packageProviders = packageProviders;
        }

        private List<string> strings;
        public void SetAll(List<string> files)
        {
            //strings.AddRange(files);

        }
        public ModulePackage Load(string file, Action next)
        {
            var ex = Path.GetExtension(file);

            var provider = _packageProviders.FirstOrDefault(p => p.FileExtension == ex);
            if (provider == null)
                throw new Exception("ex unknown");

            return provider.Load(file, next);
        }
    }
}
