using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Prototypes;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoAbout : BaseYeeProto<About>
    {
    }

    public class About
    {
        public ProtoImg Background { get; set; }
        public ProtoString SmallHeader { get; set; }
        public ProtoString LargeHeader { get; set; }
        public ProtoTextArea Content { get; set; }
        public ProtoString ButtonContent { get; set; }
    }
}
