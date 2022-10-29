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
    public class ProtoAbout : BaseYeeProto<About>
    {
    }

    public class About
    {
        [DisplayName("Изображение")]
        public ProtoImg Background { get; set; }
        [DisplayName("Подзаголовок")]
        public ProtoString SmallHeader { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString LargeHeader { get; set; }
        [DisplayName("Основной текст")]
        public ProtoTextArea Content { get; set; }
        [DisplayName("Текст кнопки")]
        public ProtoString ButtonContent { get; set; }
    }
}
