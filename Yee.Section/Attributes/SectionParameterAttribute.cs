using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Attributes
{
    public class SectionParameterAttribute : Attribute
    {
        public string DisplayName;

        public SectionParameterAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
