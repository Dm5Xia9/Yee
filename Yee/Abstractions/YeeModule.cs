using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Abstractions
{
    public abstract class BaseYeeModule
    {
        public Assembly Assembly { get; set; }

        [JsonIgnore]
        public AssemblyName AssemblyName => Assembly.GetName();

        public List<Type> Types => Assembly.GetTypes().ToList();

        public List<BaseYeeModule> Deps { get; set; }

        public IYeeModule YeeModule { get; set; }
        public YeeBuilder Builder { get; set; }

        public BaseYeeModule AddDeps(List<BaseYeeModule> deps)
        {
            Deps = deps;
            return this;
        }

    }
}
