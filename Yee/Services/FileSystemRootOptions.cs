using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Options;

namespace Yee.Services
{
    public class FileSystemRootOptions : IRootOptions
    {
        private readonly string _optionsDirectory;

        public FileSystemRootOptions(IOptions<RootOptions> options)
        {
            _optionsDirectory = options.Value.OptionsDirectory;
        }

        public T? Get<T>(string key)
        {
            var filePath = Path.Combine(_optionsDirectory, $"{key}.json");
            if (!File.Exists(filePath))
                return default(T);

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Set<T>(string key, T value)
        {

            var filePath = Path.Combine(_optionsDirectory, $"{key}.json");
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            var json = JsonConvert.SerializeObject(value);
            File.WriteAllText(filePath, json);
        }
    }
}
