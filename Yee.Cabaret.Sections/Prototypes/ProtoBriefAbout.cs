using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoBriefAbout : BaseYeeProto<BriefAbout>
    {
    }

    public class BriefAbout
    {
        public ProtoString SubHeader { get; set; }
        public ProtoString Header { get; set; }
        public ProtoString Text { get; set; }
        public List<BriefItem> BriefItems { get; set; }
    }

    public class BriefItem
    {
        public ProtoImg Image { get; set; }
    }
}
