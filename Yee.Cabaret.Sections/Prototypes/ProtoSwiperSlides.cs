using System;
using System.Collections.Generic;
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


    public class SwiperSlides
    {
        public ProtoString NextButtonContent { get; set; }
        public ProtoString PrevButtonContent { get; set; }
        public List<SwiperSlide> Slides { get; set; }
    }

    public class SwiperSlide
    {
        public ProtoImg Img { get; set; }

        public ProtoString CabSubHeading { get; set; }
        public ProtoString CabBigHeading { get; set; }

        public ProtoString ButtonContent { get; set; }
    }
}
