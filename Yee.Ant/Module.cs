using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Ant.Components;
using Yee.Ant.Services;
using Yee.Extensions;
using Yee.Services;
using Yee.Web.Extensions;

namespace Yee.Ant
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .Deps(p =>
                {
                    p.Add(typeof(AntDesign.Affix).Assembly);
                })
                 .WebApp(p =>
                 {
                     p.AddRootComponent(typeof(AntContainerComponent));
                     p.AddHead(typeof(HeadApp));
                     p.AddScript("_content/AntDesign/js/ant-design-blazor.js", true);
                     p.PossibleHeadComponent.Add(typeof(AntBlazorStyles));

                 })
                .AspConfigureServices(p =>
                {
                    p.AddAntDesign();
                    p.AddSingleton<AntDesignRouteAssemblies>();
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    var buffer = p.GetRequiredService<AntDesignRouteAssemblies>();

                    buffer.AddRange(modules
                        .ToAlignmentTrees()
                        .Where(p => p.Builder
                        .ContainsKey(Yee.Ant.Extensions.YeeBuilderExtensions.KeyUseAntDesign))
                        .Select(p => p.Assembly));


                });
        }
    }
}
