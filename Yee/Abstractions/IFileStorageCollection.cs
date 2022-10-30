using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Abstractions
{
    public interface IFileStorageCollection : IList<IFileStorage>
    {

    }

    public interface IFileStorage
    {
        public string Name { get; }
        public string PhysicalPath { get; }
        public List<YeeFileInfo> GetAllFiles();

        public YeeFileInfo GetFromLocalPath(string localPath);
        public void SetFile(YeeFileInfo yeeFileInfo, byte[] data);

    }

    public class YeeFileInfo
    {
        public YeeFileInfo(string physicalPath, string localPath)
        {
            PhysicalPath = physicalPath;
            LocalPath = localPath;
        }

        public string PhysicalPath { get; set; }
        public string LocalPath { get; set; }

        public MemoryStream OpenStream()
        {
            return new MemoryStream(File.ReadAllBytes(PhysicalPath));
        }
    }

}
