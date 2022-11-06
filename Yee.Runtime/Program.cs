using Yee.Abstractions;
using Yee.Nuget.Models;
using Yee.Nuget;
using Yee.Runtime.Builder;
using Yee.Runtime.Builder.Abstractions;
using Yee.Runtime.YeeProviders;
using Yee.Web.Services;
using Yee.Runtime.Builder.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Yee.Web;


var section = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Section.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {

                    });

var nuget = YeeAssemblyHelpers.CreateDefualtModule
            (typeof(Yee.Nuget.WebComponent.Module).Assembly)
            .AddDeps(new List<BaseYeeModule>
            {
                YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Ant.Module).Assembly)
            });

var sectionBase = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Section.Base.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        section
                    });


var entityFramework = YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.EntityFrameworkCore.Npgsql.Module).Assembly)
                            .AddDeps(new List<BaseYeeModule>
                            {
                                YeeAssemblyHelpers.CreateDefualtModule
                                    (typeof(Yee.EntityFrameworkCore.Module).Assembly)
                            });
var example = YeeAssemblyHelpers.CreateDefualtModule
            (typeof(Yee.Admin.Module).Assembly)
            .AddDeps(new List<BaseYeeModule>
            {
                section,

                nuget,
                YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.Metronic.Module).Assembly),

                YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.Ant.Module).Assembly)
                            .AddDeps(new List<BaseYeeModule>
                            {
                                YeeAssemblyHelpers.CreateDefualtModule
                                    (typeof(AntDesign.Affix).Assembly)
                            }),

                YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.EntityFrameworkCore.Identity.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        entityFramework
                    }),
                 YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Page.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        entityFramework
                    }),
            });


var cabaret = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Cabaret.Demo.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                    });



var starter = YeeAssemblyHelpers.CreateDefualtModule
    (typeof(Yee.Starter.Module).Assembly)
    .AddDeps(new List<BaseYeeModule>
    {
        nuget
    });

var builder = new YeeApplicationBuilder(args);

builder.Services.AddSingleton<NupkgStorage>();
builder.Services.AddSingleton<NupkgOptions>();
builder.Services.AddSingleton<YeeModuleStorage>();
builder.Services.AddScoped<NotFoundBuilder>();
builder.Services
    .AddSingleton<IYeeProvider<BaseYeeModule>, NupkgYeeProvider>();
builder.Services.AddSingleton<YeeViewManager>();
builder.Services.AddSingleton<BaseYeeModule>(example);
builder.Services.AddSingleton<BaseYeeModule>(cabaret);
builder.Services.AddSingleton<BaseYeeModule>(sectionBase);

builder.Build();
