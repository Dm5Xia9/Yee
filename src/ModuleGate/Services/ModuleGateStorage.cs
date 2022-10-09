using ModuleGate.Abstractions;
using ModuleGate.Models;
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
        private readonly string _modulePath;
        private readonly ModuleGateOptions _gateOptions;

        public ModuleGateStorage(ModuleGateOptions options)
        {
            _gateOptions = options;

            _modulePath = options.ContextPath;
            if(File.Exists(_modulePath))
            {
                var json = File.ReadAllText(_modulePath);

                _modules = JsonConvert.DeserializeObject<Modules>(json)!;
            }
        }

        public void AddModule(MgModuleMetadata mgModule)
        {
            _modules.Add(mgModule);
        }

        public void Save()
        {
            if (!File.Exists(_modulePath))
            {
                File.Create(_modulePath).Close();
            }

            File.WriteAllText(_modulePath, JsonConvert.SerializeObject(_modules));
        }

        public Modules GetAllModules()
        {
            return _modules;
        } 
    }

    public class Modules : List<MgModuleMetadata>
    {
        
    }

}
