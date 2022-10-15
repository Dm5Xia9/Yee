using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Section.Extensions;
using Yee.Section.Handlers.Base;
using Yee.Section.Prototypes;
using Yee.Section.Services;
using Yee.Services;

namespace Yee.Section
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            SectionState buffer = null;

            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<SectionState>();
                })
                .YeeSections(p =>
                {
                    p.ProtoHandlers.Add(typeof(ProtoString), typeof(StringProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoBool), typeof(BoolProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoLink), typeof(LinkProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoNumber), typeof(NumberProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoCssClass), typeof(CssProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoNavigation), typeof(NavigationProtoHandler));
                    p.ProtoHandlers.Add(typeof(ProtoImg), typeof(ImgProtoHandler));

                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<SectionState>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyYeeSections, buffer);
                });
        }
    }
}
