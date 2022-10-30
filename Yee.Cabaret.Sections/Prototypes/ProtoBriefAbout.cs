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
    public class ProtoBriefAbout : BaseYeeProto<BriefAbout>
    {
    }

    public class ProtoBriefImages : BaseYeeProto<List<ImageItem>>
    {
    }

    public class BriefAbout
    {
        [DisplayName("Подзаголовок")]
        public ProtoString SubHeader { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
        [DisplayName("Текст")]
        public ProtoString Text { get; set; }
    }

    public class ImageItem
    {
        [DisplayName("Изображение")]
        public ProtoImg Image { get; set; }
    }
}
