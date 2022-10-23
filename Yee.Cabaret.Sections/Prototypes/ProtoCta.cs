using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoCta : BaseYeeProto<Cta>
    {
    }

    public class Cta
    {
        public ProtoString Header { get; set; }
        public ProtoString TextBeforeVideo { get; set; }
        public ProtoImg Img { get; set; }
    }
}
