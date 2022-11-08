using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.FileStorage.Services
{
    public class FileStorageService: IFileStorage
    {
        private FileStorageOptions _options;

        public string PhysicalPath => _options.RootPath;

        public string Name => "DefualtFileStorage";

        public FileStorageService(IRootOptions rootOptions)
        {
            _options = rootOptions.Get<FileStorageOptions>("FileStorageOptions");

            if (_options == null)
            {
                _options = new FileStorageOptions
                {
                    RootPath = Path.Combine(Directory.GetCurrentDirectory(), "fileStorage")
                };

                if(Directory.Exists(_options.RootPath) == false)
                    Directory.CreateDirectory(_options.RootPath);

                rootOptions.Set("FileStorageOptions", _options);
            }
        }


        public List<YeeFileInfo> GetAllFiles()
        {
            List<YeeFileInfo> list = new List<YeeFileInfo>();
            foreach (var file in Directory.GetFiles(_options.RootPath, "*", SearchOption.AllDirectories))
            {
                list.Add(new YeeFileInfo(file, file.Replace(_options.RootPath, "")));
            }

            return list;
        }

        public void SetFile(YeeFileInfo yeeFileInfo, byte[] data)
        {
            var fillPath = Path.Combine(_options.RootPath, yeeFileInfo.LocalPath);

            var directory = Path.GetDirectoryName(fillPath);

            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);


            File.WriteAllBytes(fillPath, data);

        }

        public YeeFileInfo GetFromLocalPath(string localPath)
        {
            var fillPath = Path.Combine(_options.RootPath, localPath);
            if (File.Exists(fillPath) == false)
                return null;


            return new YeeFileInfo(fillPath, localPath);
        }
    }

    public class FileStorageOptions
    {
        public string RootPath { get; set; }
    }
}
