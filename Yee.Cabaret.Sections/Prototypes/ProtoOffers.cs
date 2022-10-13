using System;
using System.Collections.Generic;
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

    public class CabOffers
    {
        public ProtoString SmallHeading { get; set; }
        public CabOffersMainHeading MainHeading { get; set; }

        public List<CabOfferCard> OfferCards { get; set; }
    }

    public class CabOfferCard
    {
        public ProtoString Title { get; set; }
        public ProtoString Description { get; set; }
        public ProtoString PriceDisplay { get; set; }
        public ProtoNumber Price { get; set; }

        public ProtoString CurrencyDisplay { get; set; }

        public ProtoImg Img { get; set; }

        public ProtoBool Popular { get; set; }
        public ProtoImg LogoImg { get; set; }
        public string GetDisplayPrice()
        {
            return $"{PriceDisplay}: {CurrencyDisplay}{Price}";
        }
    }

    public class CabOffersMainHeading
    {
        public ProtoString Content { get; set; }
        public ProtoString PrimaryContent { get; set; }
    }
}
