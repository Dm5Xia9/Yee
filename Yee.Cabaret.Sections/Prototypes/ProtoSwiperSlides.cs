using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Prototypes;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoSwiperSlides : BaseYeeProto<SwiperSlides>
    {

    }


    public class SwiperSlides
    {
        public string NextButtonContent { get; set; }
        public string PrevButtonContent { get; set; }
        public List<SwiperSlide> Slides { get; set; }
    }

    public class SwiperSlide
    {
        public ProtoImg Img { get; set; }

        public string CabSubHeading { get; set; }
        public string CabBigHeading { get; set; }

        public string ButtonContent { get; set; }
    }
}
