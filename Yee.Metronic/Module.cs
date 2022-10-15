using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Metronic.Services;
using Yee.Services;
using Yee.Web.Extensions;

namespace Yee.Metronic
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .WebApp(p =>
                {
                    p.AddHead(typeof(HeadApp));
                    p.AddScript("/themes/metronic/dist/assets/plugins/global/plugins.bundle.js");
                    p.AddScript("/themes/metronic/dist/assets/plugins/custom/prismjs/prismjs.bundle.js");
                    p.AddScript("/themes/metronic/dist/assets/js/scripts.bundle.js");
                    p.AddScript("/themes/metronic/dist/assets/js/pages/features/miscellaneous/blockui.js");
                    p.AddScript("/themes/metronic/dist/assets/plugins/custom/fullcalendar/fullcalendar.bundle.js");
                    p.AddScript("/themes/metronic/dist/assets/js/pages/widgets.js");

                })
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<MetronicRouteAssemblies>();
                    
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    var buffer = p.GetRequiredService<MetronicRouteAssemblies>();

                    buffer.AddRange(modules
                        .ToAlignmentTrees()
                        .Where(p => p.Builder
                        .ContainsKey(Yee.Metronic.Extensions.YeeBuilderExtensions.KeyUseMetconic))
                        .Select(p => p.Assembly));


                });
        }
    }
}
