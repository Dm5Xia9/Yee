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
    public class ProtoMenu : BaseYeeProto<Menu>
    {
    }

    public class ProtoMenuItems : BaseYeeProto<List<MenuItem>>
    {
    }

    public class Menu
    {
        [DisplayName("Подзаголовок")]
        public ProtoString CabSubHeading { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString CabBigHeading { get; set; }
        [DisplayName("Валюта")]
        public ProtoString PriceDisplay { get; set; }
        [DisplayName("Текст кнопки")]
        public ProtoString ButtonContent { get; set; }
        [DisplayName("Ссылка кнопки")]
        public ProtoLink ButtonUrl { get; set; }
        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }
    }

    public class MenuItem
    {
        [DisplayName("Категория")]
        public ProtoString Category { get; set; }
        [DisplayName("Название")]
        public ProtoString ItemName { get; set; }
        [DisplayName("Ингридиенты")]
        public ProtoString Ingridients { get; set; }
        [DisplayName("Цена")]
        public ProtoNumber Price { get; set; }
        [DisplayName("Новая")]
        public ProtoBool IsNew { get; set; }
    }
}
