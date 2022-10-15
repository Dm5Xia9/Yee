using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
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
                });

        }
    }
}
