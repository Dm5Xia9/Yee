using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public class ModuleGateAttribute : Attribute
    {
        public ModuleGateSpecialType Special { get; set; }
            = ModuleGateSpecialType.None;
    }

    public enum ModuleGateSpecialType
    {
        None,
        OptionsModule
    }
}
