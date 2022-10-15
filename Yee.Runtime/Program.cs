using Yee.Abstractions;
using Yee.Nuget.Models;
using Yee.Nuget;
using Yee.Runtime.Builder;
using Yee.Runtime.Builder.Abstractions;
using Yee.Runtime.YeeProviders;
using Yee.Web.Services;
using Yee.Runtime.Builder.Helpers;
using Microsoft.Extensions.DependencyInjection;

var section = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Section.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {

                    });

var cabaretSection = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Cabaret.Sections.Module).Assembly)
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

var adminSwagger = YeeAssemblyHelpers.CreateDefualtModule
            (typeof(Yee.Admin.Swagger.Module).Assembly)
            .AddDeps(new List<BaseYeeModule>
            {
                example
            });

var swagger = YeeAssemblyHelpers.CreateDefualtModule
    (typeof(Yee.Swagger.Module).Assembly);



var core = YeeAssemblyHelpers.CreateDefualtModule
    (typeof(Yee.CoreLayout.Module).Assembly);


var builder = new YeeApplicationBuilder(args);

builder.Services.AddSingleton<NupkgStorage>();
builder.Services.AddSingleton<NupkgOptions>();
builder.Services.AddSingleton<YeeModuleStorage>();
builder.Services
    .AddSingleton<IYeeProvider<BaseYeeModule>, NupkgYeeProvider>();
builder.Services.AddSingleton<YeeViewManager>();
builder.Services.AddSingleton<BaseYeeModule>(adminSwagger);
builder.Services.AddSingleton<BaseYeeModule>(example);
builder.Services.AddSingleton<BaseYeeModule>(swagger);
builder.Services.AddSingleton<BaseYeeModule>(core);
builder.Services.AddSingleton<BaseYeeModule>(cabaretSection);

builder.Build();
