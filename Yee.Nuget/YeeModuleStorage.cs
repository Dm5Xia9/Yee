using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Nuget.Models;
using Yee.Options;

namespace Yee.Nuget
{
    public class YeeModuleStorage
    {
        private readonly Modules _modules = new Modules();
        private readonly IRootOptions _rootOptions;

        public YeeModuleStorage(IRootOptions rootOptions)
        {
            _rootOptions = rootOptions;

            _modules = rootOptions.Get<Modules>("CurrentModules");
            if(_modules == null)
            {
                _modules = new Modules();
            }

        }

        public void AddModule(NupkgModuleMetadata mgModule)
        {
            _modules.Add(mgModule);
        }

        public void Save()
        {
            _rootOptions.Set("CurrentModules", _modules);
        }

        public Modules GetAllModules()
        {
            return _modules;
        }
    }

    public class Modules : List<NupkgModuleMetadata>
    {

    }
}
