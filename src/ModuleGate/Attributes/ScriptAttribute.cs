using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate
{
    public class ScriptAttribute : MarkerAttribute
    {
        public ScriptAttribute(string localUri) : base(localUri)
        {
        }
    }
}
