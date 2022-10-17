using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.FileStorage.Services
{
    public class FileStorageService
    {
        private FileStorageOptions _options;
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

        public string GetRootPath()
        {
            return _options.RootPath;
        }

        public void SetFile(string fileName, byte[] bytes)
        {
            File.WriteAllBytes(fileName, bytes);
        }

        public IEnumerable<string> GetAllPublicFiles()
        {
            foreach(var file in Directory.GetFiles(_options.RootPath))
            {
                yield return file.Replace(_options.RootPath, "");
            }
        }
        
    }

    public class FileStorageOptions
    {
        public string RootPath { get; set; }
    }
}
