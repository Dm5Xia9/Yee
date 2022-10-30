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
    public class ProtoNews : BaseYeeProto<News>
    {
    }

    public class ProtoNewsItems : BaseYeeProto<List<NewsItem>>
    {
    }

    public class News
    {
        [DisplayName("Подзаголовок")]
        public ProtoString SubHeader { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
    }

    public class NewsItem
    {
        [DisplayName("Изображение")]
        public ProtoImg Image { get; set; }
        [DisplayName("Описание")]
        public ProtoString Description { get; set; }
        [DisplayName("Дата")]
        public ProtoDate Date { get; set; }
        [DisplayName("Место проведения")]
        public ProtoString Place { get; set; }
    }
}
