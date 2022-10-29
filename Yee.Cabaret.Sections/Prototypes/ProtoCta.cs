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
    public class ProtoCta : BaseYeeProto<Cta>
    {
    }

    public class Cta
    {
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
        [DisplayName("Текст")]
        public ProtoString TextBeforeVideo { get; set; }
        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }
    }
}
