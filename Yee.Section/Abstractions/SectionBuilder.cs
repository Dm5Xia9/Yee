using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Abstractions
{
    public class SectionBuilder : Dictionary<string, SectionParameterValue>
    {
        public string DisplayName
        {
            get
            {
                return "";
            }
        }
        public SectionBuilder()
        {
            
        }
    }

    public class SectionParameterValue
    {
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}
