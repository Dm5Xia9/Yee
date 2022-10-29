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

    public class Menu
    {
        public ProtoString CabSubHeading { get; set; }
        public ProtoString CabBigHeading { get; set; }
        public ProtoString PriceDisplay { get; set; }
        public ProtoImg Img { get; set; }
        public List<MenuTab> Tabs { get; set; }
    }

    public class MenuTab
    {
        public ProtoString TabName { get; set; }
        public ProtoString ButtonContent { get; set; }
        public ProtoLink ButtonUrl { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public ProtoString ItemName { get; set; }
        public ProtoString Ingridients { get; set; }
        public ProtoNumber Price { get; set; }
        public ProtoBool IsNew { get; set; }
    }
}
