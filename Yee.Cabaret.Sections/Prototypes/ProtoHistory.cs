using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
    }

    public class HistoryItem
    {
        [DisplayName("Год")]
        public ProtoString Year { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString Title { get; set; }
        [DisplayName("Описание")]
        public ProtoString Description { get; set; }
    }
}
