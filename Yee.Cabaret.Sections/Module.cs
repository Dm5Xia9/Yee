﻿using System;
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
                    p.AddSection<CabMainMenuSection>();
                    p.AddSection<CabCtaSection>();
                    p.AddSection<CabTestimonialsSection>();
                    p.AddSection<CabReviewsSegments>();
                    p.AddSection<CabNewsSection>();
                    p.AddSection<CabEventsSection>();
                    p.AddSection<CabFooterInfoSection>();
                    p.AddSection<CabBriefAboutSection>();
                    p.AddSection<CabHistorySection>();
                    p.AddSection<HtmlSegment>();
                    p.AddSection<CabTeamSection>();
                    p.AddSection<CabShowcasesSection>();
                    p.AddSection<CabFAQSection>();

                    p.AddPrototype<ProtoOffers, ProtoOffersHandler>();
                    p.AddPrototype<ProtoOfferCards, ProtoOffersCardHandler>();
                    p.AddPrototype<ProtoSwiperSlides, ProtoSwiperSlidesHandler>();
                    p.AddPrototype<ProtoSwiperSlidesItems, ProtoSwiperSlidesItemsHandler>();
                    p.AddPrototype<ProtoAbout, ProtoAboutHandler>();
                    p.AddPrototype<ProtoCta, ProtoCtaHandler>();
                    p.AddPrototype<ProtoMenu, ProtoMenuHandler>();
                    p.AddPrototype<ProtoMenu, ProtoMainMenuHandler>();
                    p.AddPrototype<ProtoMenuItems, ProtoMenuItemsHandler>();
                    p.AddPrototype<ProtoTestimonial, ProtoTestimonialHandler>();
                    p.AddPrototype<ProtoTestimonialItems, ProtoReviewsHandler>();
                    p.AddPrototype<ProtoTestimonialItems, ProtoTestimonialItemsHandler>();
                    p.AddPrototype<ProtoNews, ProtoNewsHandler>();
                    p.AddPrototype<ProtoNewsItems, ProtoEventsItemsHandler>();
                    p.AddPrototype<ProtoNewsItems, ProtoNewsItemsHandler>();
                    p.AddPrototype<ProtoFooterInfo, ProtoFooterInfoHandler>();
                    p.AddPrototype<ProtoFooterInfoItems, ProtoFooterInfoItemsHandler>();
                    p.AddPrototype<ProtoHtml, ProtoHtmlHandler>();
                    p.AddPrototype<ProtoBriefAbout, ProtoBriefAboutHandler>();
                    p.AddPrototype<ProtoBriefImages, ProtoBriefImagesHandler>();
                    p.AddPrototype<ProtoHistory, ProtoHistoryHandler>();
                    p.AddPrototype<ProtoHistoryItems, ProtoHistoryItemsHandler>();
                    p.AddPrototype<ProtoTeam, ProtoTeamHandler>();
                    p.AddPrototype<ProtoShowcases, ProtoShowcasesHandler>();
                    p.AddPrototype<ProtoFAQ, ProtoFAQHandler>();
                    p.AddPrototype<ProtoQuestions, ProtoQuestionsHandler>();
                });

        }
    }
}
