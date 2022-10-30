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
    public class ProtoHtml : BaseYeeProto<HtmlText>
    {
    }

    public class HtmlText
    {
        [DisplayName("Тело HTML")]
        public ProtoTextArea Html { get; set; }
    }
}
