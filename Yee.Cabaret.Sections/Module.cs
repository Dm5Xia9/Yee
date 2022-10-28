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
                    p.AddSection<CabNewsSection>();
                    p.AddSection<CabFooterInfoSection>();
                    p.AddSection<CabBriefAboutSection>();
                    p.AddSection<CabHistorySection>();
                    p.AddSection<HtmlSegment>();

                    p.AddPrototype<ProtoOffers, ProtoOffersHandler>();
                    p.AddPrototype<ProtoOfferCards, ProtoOffersCardHandler>();
                    p.AddPrototype<ProtoSwiperSlides, ProtoSwiperSlidesHandler>();
                    p.AddPrototype<ProtoAbout, ProtoAboutHandler>();
                    p.AddPrototype<ProtoMenu, ProtoMenuHandler>();
                    p.AddPrototype<ProtoCta, ProtoCtaHandler>();
                    p.AddPrototype<ProtoTestimonial, ProtoTestimonialHandler>();
                    p.AddPrototype<ProtoNews, ProtoNewsHandler>();
                    p.AddPrototype<ProtoFooterInfo, ProtoFooterInfoHandler>();
                    p.AddPrototype<ProtoHtml, ProtoHtmlHandler>();
                    p.AddPrototype<ProtoBriefAbout, ProtoBriefAboutHandler>();
                    p.AddPrototype<ProtoHistory, ProtoHistoryHandler>();
                });

        }
    }
}
