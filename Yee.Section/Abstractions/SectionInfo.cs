using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Abstractions
{
    public class SectionInfo
    {
        public Type Type { get; set; }
        public List<SectionParameter> Parameters { get; set; }
    }


    public class SectionParameter
    {
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public Type ParamType { get; set; }
    }
}
