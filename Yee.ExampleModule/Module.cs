using Microsoft.Extensions.DependencyInjection;
using ModuleGate.DefualtExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Cabaret.Sections.Handlers;
using Yee.Cabaret.Sections.Prototypes;
using Yee.Extensions;
using Yee.Section.Extensions;
using Yee.Web.Extensions;

namespace Yee.ExampleModule
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<WeatherForecastService>();
                })
                .Deps(p =>
                {
                    p.Add(typeof(AntDesign.ActionColumn).Assembly);
                })
                .YeeSections(p =>
                {
                    p.AddPrototype<ProtoOffers, ProtoOffersHandler>();
                })
                .WebApp(p =>
                {
                    p.AddRouter(typeof(App));
                });
        }
    }
}
