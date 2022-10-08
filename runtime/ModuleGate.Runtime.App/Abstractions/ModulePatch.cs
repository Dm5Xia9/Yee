using ModuleGate.Runtime.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public class ModulePatch
    {
        public StaticFileGroup RootStaticFiles { get; set; }
        public List<AppComponentType> AppComponentTypes { get; set; }
    }

    public class AppComponentType
    {
        public Type Type { get; set; }
        public AppComponentAttribute Meta { get; set; }
    }
}
