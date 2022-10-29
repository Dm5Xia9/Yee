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

    public class ProtoBriefImages : BaseYeeProto<List<ImageItem>>
    {
    }

    public class BriefAbout
    {
        public ProtoString SubHeader { get; set; }
        public ProtoString Header { get; set; }
        public ProtoString Text { get; set; }
    }

    public class ImageItem
    {
        public ProtoImg Image { get; set; }
    }
}
