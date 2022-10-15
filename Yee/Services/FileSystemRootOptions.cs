using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            return GetDetail<T>(key)!.Value;
        }

        public IEnumerable<RootOption<JObject>> GetAll()
        {
            List<RootOption<JObject>> options = new List<RootOption<JObject>>();

            foreach(var file in Directory.GetFiles(_optionsDirectory))
            {
                var json = File.ReadAllText(file);
                var option = JsonConvert.DeserializeObject<RootOption<JObject>>(json);

                options.Add(option);
            }

            return options.ToList();
        }

        public RootOption<T> GetDetail<T>(string key)
        {
            var filePath = Path.Combine(_optionsDirectory, $"{key}.json");
            if (!File.Exists(filePath))
                return null;

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<RootOption<T>>(json);
        }

        public void Set<T>(string key, T value)
        {

            var filePath = Path.Combine(_optionsDirectory, $"{key}.json");
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            var optionsObj = new RootOption<T>
            {
                TypeName = typeof(T).FullName,
                OptionsKey = key,
                AssemblyName = typeof(T).Assembly.GetName().Name,
                Value = value
            };

            var json = JsonConvert.SerializeObject(optionsObj);
            File.WriteAllText(filePath, json);
        }
    }
}
