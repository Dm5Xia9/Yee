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
    public class ProtoSwiperSlides : BaseYeeProto<SwiperSlides>
    {
    }

    public class ProtoSwiperSlidesItems : BaseYeeProto<List<SwiperSlide>>
    {
    }

    public class SwiperSlides
    {
        [DisplayName("Текст кнопки \"вперёд\"")]
        public ProtoString NextButtonContent { get; set; }
        [DisplayName("Текст кнопки \"назад\"")]
        public ProtoString PrevButtonContent { get; set; }
    }

    public class SwiperSlide
    {
        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }

        [DisplayName("Подзаголовок")]
        public ProtoString CabSubHeading { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString CabBigHeading { get; set; }

        [DisplayName("Текст кнопки")]
        public ProtoString ButtonContent { get; set; }
        [DisplayName("Ссылка кнопки")]
        public ProtoLink ButtonLink { get; set; }
    }
}
