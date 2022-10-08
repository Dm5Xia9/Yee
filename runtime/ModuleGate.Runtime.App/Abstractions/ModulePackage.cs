using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Runtime.App.Abstractions
{
    public class ModulePackage
    {
        public Assembly Target { get; set; }
        public AssemblyName TargetName { get; set; }
        public List<ModulePackage> ChildPackages { get; set; }
        public ModuleStartup Startup { get; set; }
        public ModulePatch Patch { get; set; }
    }
}
