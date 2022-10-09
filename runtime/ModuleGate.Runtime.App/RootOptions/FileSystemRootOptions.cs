using Microsoft.Extensions.Configuration;
using ModuleGate.Abstractions;
using ModuleGate.Runtime.App.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.RootOptions
{
    public class FileSystemRootOptions : IRootOptions
    {
        private readonly IConfiguration _configuration;
        private readonly string _optionsDirectory;

        public FileSystemRootOptions(IConfiguration configuration)
        {
            _configuration = configuration;
            _optionsDirectory = configuration
                .GetSection("OptionsDirectory")
                .Value;
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
