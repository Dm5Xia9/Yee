using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Attributes.Options
{
    public class OptionSectionNode : Attribute
    {
        public string NodeName { get; init; }

        public OptionSectionNode(string nodeName)
        {
            NodeName = nodeName;
        }
    }
}
