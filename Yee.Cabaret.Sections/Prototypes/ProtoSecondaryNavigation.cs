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
    public class ProtoSecondaryNavigation : BaseYeeProto<SecondaryNavigation>
    {
    }

    public class SecondaryNavigation
    {
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
        [DisplayName("Ссылка поиска")]
        public ProtoLink SearchUrl { get; set; }
        [DisplayName("Текст кнопки")]
        public ProtoString ButtonContent { get; set; }
        [DisplayName("Ссылка кнопки")]
        public ProtoLink ButtonUrl { get; set; }
        [DisplayName("Изображение")]
        public ProtoImg Logo { get; set; }
    }
}
