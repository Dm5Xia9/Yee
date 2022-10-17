using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Prototypes;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoOffers : BaseYeeProto<CabOffers>
    {

    }

    public class ProtoOfferCards : BaseYeeProto<List<CabOfferCard>>
    {

    }


    public class CabOffers
    {
        [DisplayName("Название")]
        public ProtoString SmallHeading { get; set; }

        public CabOffersMainHeading MainHeading { get; set; }
    }


    public class CabOfferCard
    {
        [DisplayName("Главное предложение")]
        public ProtoBool Primary { get; set; }

        [DisplayName("Название")]
        public ProtoString Title { get; set; }

        [DisplayName("Описание")]
        public ProtoString Description { get; set; }


        [DisplayName("Цена текст")]
        public ProtoString PriceDisplay { get; set; }

        [DisplayName("Цена")]
        public ProtoNumber Price { get; set; }

        [DisplayName("Валюта")]
        public ProtoString CurrencyDisplay { get; set; }

        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }

        [DisplayName("Популярный?")]
        public ProtoBool Popular { get; set; }

        [DisplayName("Логотип")]
        public ProtoImg LogoImg { get; set; }
        public string GetDisplayPrice()
        {
            return $"{PriceDisplay}: {CurrencyDisplay}{Price}";
        }
    }

    public class CabOffersMainHeading
    {
        [DisplayName("Заголовок")]
        public ProtoString Content { get; set; }

        [DisplayName("Выделенный заголовок")]
        public ProtoString PrimaryContent { get; set; }
    }
}
