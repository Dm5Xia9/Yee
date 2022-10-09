using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Services
{
    public class ModuleGateStorage
    {
        private readonly Modules _modules = new Modules();
        private readonly string _rootPath;
        public ModuleGateStorage(string rootPath)
        {
            _rootPath = rootPath;
            string modulePath = Path.Combine(_rootPath, "modules.json");
            if (!Directory.Exists(rootPath))
            {
                NotCreated = true;
            }
            else
            {
                if (!File.Exists(modulePath))
                {
                    NotCreated = true;

                }
                else
                {
                    var json = File.ReadAllText(modulePath);

                    _modules = JsonConvert.DeserializeObject<Modules>(json)!;
                    NotCreated = false;
                }
            }
        }

        public bool NotCreated { get; private set; }
        public void AddModule(string path)
        {
            _modules.Add(new Module
            {
                Path = path
            });
        }

        public void Save()
        {
            string modulePath = Path.Combine(_rootPath, "modules.json");

            if (NotCreated == true)
            {
                Directory.CreateDirectory(_rootPath);

                File.Create(modulePath).Close();

                NotCreated = false;
            }

            File.WriteAllText(modulePath, JsonConvert.SerializeObject(_modules));
        }

        public List<string> GetAllModules()
        {
            return _modules.Select(p => p.Path).ToList();
        } 
    }

    public class Modules : List<Module>
    {
        
    }

    public class Module
    {
        public string Path { get; set; }
    }
}
