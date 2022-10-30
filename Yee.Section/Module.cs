using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Section.Extensions;
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
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    buffer = p.GetRequiredService<SectionState>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyYeeSections, buffer);
                });
        }
    }
}
