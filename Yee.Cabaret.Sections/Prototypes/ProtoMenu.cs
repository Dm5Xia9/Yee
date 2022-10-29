using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoMenu : BaseYeeProto<Menu>
    {
    }

    public class ProtoMenuItems : BaseYeeProto<List<MenuItem>>
    {
    }

    public class Menu
    {
        public ProtoString CabSubHeading { get; set; }
        public ProtoString CabBigHeading { get; set; }
        public ProtoString PriceDisplay { get; set; }
        public ProtoString ButtonContent { get; set; }
        public ProtoLink ButtonUrl { get; set; }
        public ProtoImg Img { get; set; }
    }

    public class MenuItem
    {
        public ProtoString Category { get; set; }
        public ProtoString ItemName { get; set; }
        public ProtoString Ingridients { get; set; }
        public ProtoNumber Price { get; set; }
        public ProtoBool IsNew { get; set; }
    }
}
