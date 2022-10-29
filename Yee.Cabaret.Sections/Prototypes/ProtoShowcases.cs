using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoShowcases : BaseYeeProto<List<Showcase>>
    {
    }

    public class Showcase
    {
        public ProtoImg Img { get; set; }
    }
}
