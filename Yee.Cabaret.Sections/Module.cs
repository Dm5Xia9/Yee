using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Cabaret.Sections.Handlers;
using Yee.Cabaret.Sections.Prototypes;
using Yee.Section.Extensions;

namespace Yee.Cabaret.Sections
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .YeeSections(p =>
                {
                    p.AddSection<CabNavigation>();
                    p.AddSection<CabOffersSection>();
                    p.AddSection<CabOneNavigation>();
                    p.AddSection<CabSwiperSection>();
                    p.AddSection<CabAboutSection>();
                    p.AddSection<CabMenuSection>();
                    p.AddSection<CabCtaSection>();
                    p.AddSection<CabTestimonialsSection>();
                    p.ProtoHandlers.Add(typeof(ProtoOffers), typeof(ProtoOffersHandler));
                    p.ProtoHandlers.Add(typeof(ProtoOfferCards), typeof(ProtoOffersCardHandler));
                    p.ProtoHandlers.Add(typeof(ProtoSwiperSlides), typeof(ProtoSwiperSlidesHandler));
                    p.ProtoHandlers.Add(typeof(ProtoAbout), typeof(ProtoAboutHandler));
                    p.ProtoHandlers.Add(typeof(ProtoMenu), typeof(ProtoMenuHandler));
                    p.ProtoHandlers.Add(typeof(ProtoCta), typeof(ProtoCtaHandler));
                    p.ProtoHandlers.Add(typeof(ProtoTestimonial), typeof(ProtoTestimonialHandler));
                });

        }
    }
}
