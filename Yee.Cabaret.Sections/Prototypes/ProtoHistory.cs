using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoHistory : BaseYeeProto<History>
    {
    }

    public class ProtoHistoryItems : BaseYeeProto<List<HistoryItem>>
    {
    }

    public class History
    {
        public ProtoString Header { get; set; }
    }

    public class HistoryItem
    {
        public ProtoString Year { get; set; }
        public ProtoString Title { get; set; }
        public ProtoString Description { get; set; }
    }
}
