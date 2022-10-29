using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoFooterInfo : BaseYeeProto<FooterInfo>
    {
    }

    public class FooterInfo
    {
        public ProtoString ButtonText { get; set; }
        public ProtoLink ButtonUrl { get; set; }
        public List<FooterInfoItem> InfoItems { get; set; }
    }

    public class FooterInfoItem
    {
        //public ProtoSelect Icon { get; set; }
        public ProtoString Title { get; set; }
        public ProtoString Description { get; set; }
    }
}
