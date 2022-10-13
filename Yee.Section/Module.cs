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
            ProtoHandlerCollection buffer = null;

            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<ProtoHandlerCollection>();
                })
                .YeeSections(p =>
                {
                    p.Add(typeof(ProtoString), typeof(StringProtoHandler));
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<ProtoHandlerCollection>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyYeeSections, buffer);
                });
        }
    }
}
