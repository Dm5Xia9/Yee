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
    }
}
