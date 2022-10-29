using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoNews : BaseYeeProto<News>
    {
    }

    public class ProtoNewsItems : BaseYeeProto<List<NewsItem>>
    {
    }

    public class News
    {
        public ProtoString SubHeader { get; set; }
        public ProtoString Header { get; set; }
    }

    public class NewsItem
    {
        public ProtoImg Image { get; set; }
        public ProtoString Description { get; set; }
        public ProtoDate Date { get; set; }
        public ProtoString Place { get; set; }
    }
}
