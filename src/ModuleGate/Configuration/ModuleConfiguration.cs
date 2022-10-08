using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Configuration
{
    public class ModuleConfiguration : IConfiguration
    {
        private readonly ConfigurationManager _manager;

        public string this[string key] { get => _manager[key]; set => _manager[key] = value; }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return _manager.GetChildren();
        }

        public IChangeToken GetReloadToken()
        {
            return (_manager as IConfiguration).GetReloadToken();
        }

        public IConfigurationSection GetSection(string key)
        {
            return _manager.GetSection(key);
        }
    }
}
