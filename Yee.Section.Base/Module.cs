using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Section.Base.Handlers;
using Yee.Section.Extensions;

namespace Yee.Section.Base
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder.YeeSections(p =>
            {
                p.AddPrototype<ProtoString, StringProtoHandler>();
                p.AddPrototype<ProtoBool, BoolProtoHandler>();
                p.AddPrototype<ProtoLink, LinkProtoHandler>();
                p.AddPrototype<ProtoNumber, NumberProtoHandler>();
                p.AddPrototype<ProtoCssClass, CssProtoHandler>();
                p.AddPrototype<ProtoNavigation, NavigationProtoHandler>();
                p.AddPrototype<ProtoImg, ImgProtoHandler>();
                p.AddPrototype<ProtoTextArea, TextAreaProtoHandler>();
                p.AddPrototype<ProtoDate, DatePickerProtoHandler>();

            });
        }


    }
}
