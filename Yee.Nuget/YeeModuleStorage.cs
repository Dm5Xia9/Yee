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
        private readonly ListBox<NupkgModuleMetadata> _modules = new ListBox<NupkgModuleMetadata>();
        private readonly IRootOptions _rootOptions;

        public YeeModuleStorage(IRootOptions rootOptions)
        {
            _rootOptions = rootOptions;

            _modules = rootOptions.Get<ListBox<NupkgModuleMetadata>>("CurrentModules");
            if(_modules == null)
            {
                _modules = new ListBox<NupkgModuleMetadata>();
            }

        }

        public void AddModule(NupkgModuleMetadata mgModule)
        {
            _modules.Value.Add(mgModule);
        }

        public void Save()
        {
            _rootOptions.Set("CurrentModules", _modules);
        }

        public ListBox<NupkgModuleMetadata> GetAllModules()
        {
            return _modules;
        }
    }

    public class Modules : List<NupkgModuleMetadata>
    {

    }
}
