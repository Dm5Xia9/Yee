using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Forms.Abstractions;
using Yee.Forms.Extensions;
using Yee.Forms.SharpForms;
using Yee.MVC;
using Yee.MVC.Extensions;
using Yee.Services;

namespace Yee.Forms
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<SharpFormCollection>();
                    p.AddSingleton<ISharpFormFactory, SharpFormFactory>();
                    p.AddSingleton<ISharpFormLinksRepository, RootSharpFormLinksRepository>();
                    p.AddSingleton<CombineFormLinksRepository>();
                })
                .YeeForms(p =>
                {
                    p.Add<ExampleForm>();
                })
                .AspPostBuild(p =>
                {
                    var modules = p.GetRequiredService<YeeModuleManager>();
                    var buffer = p.GetRequiredService<SharpFormCollection>();
                    modules.HandlersFromId(Extensions.YeeBuilderExtensions.KeyYeeForm, buffer);
                })
                .AspEndpoints(p =>
                {
                    p.AddLastArea(
                        name: "YeeForms",
                        pattern: "forms/{action=Index}/{id?}");
                });
        }
    }
}
