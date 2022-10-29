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
    public class ProtoFooterInfo : BaseYeeProto<FooterInfo>
    {
    }

    public class ProtoFooterInfoItems : BaseYeeProto<List<FooterInfoItem>>
    {
    }

    public class FooterInfo
    {
        [DisplayName("Текст кнопки")]
        public ProtoString ButtonText { get; set; }
        [DisplayName("Ссылка кнопки")]
        public ProtoLink ButtonUrl { get; set; }
    }

    public class FooterInfoItem
    {
        //public ProtoSelect Icon { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString Title { get; set; }
        [DisplayName("Описание")]
        public ProtoString Description { get; set; }
    }
}
