using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Yee.Runtime.YeeProviders
{
    public class AssemblyPhysicalFileProvider : IFileProvider
    {
        private readonly PhysicalFileProvider _physicalFileProvider;
        private readonly string _assemblyName;
        private readonly string _firstPath;
        public AssemblyPhysicalFileProvider(string path, string assemblyName)
        {
            _physicalFileProvider = new PhysicalFileProvider(path);
            _assemblyName = assemblyName;

            _firstPath = $"/_content/{_assemblyName}";
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return _physicalFileProvider.GetDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if (subpath.StartsWith(_firstPath))
            {
                var sPath = subpath.Substring(_firstPath.Length);
                return _physicalFileProvider.GetFileInfo(sPath);
            }

            return null;

        }

        public IChangeToken Watch(string filter)
        {
            return _physicalFileProvider.Watch(filter);
        }
    }
}
