using Yee.Abstractions;
using Yee.Nuget.Models;
using Yee.Nuget;
using Yee.Runtime.Builder;
using Yee.Runtime.Builder.Abstractions;
using Yee.Runtime.YeeProviders;
using Yee.Web.Services;
using Yee.Runtime.Builder.Helpers;
using Microsoft.Extensions.DependencyInjection;

var example = YeeAssemblyHelpers.CreateDefualtModule
            (typeof(Yee.ExampleModule.Module).Assembly)
            .AddDeps(new List<BaseYeeModule>
            {
                YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.EntityFrameworkCore.Identity.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.EntityFrameworkCore.Npgsql.Module).Assembly)
                            .AddDeps(new List<BaseYeeModule>
                            {
                                 YeeAssemblyHelpers.CreateDefualtModule
                                     (typeof(Yee.EntityFrameworkCore.Module).Assembly)

                            })
                    }),
                 YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Forms.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.MVC.Module).Assembly)
                    }),

                  YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Cabaret.CoreFrontLibraries.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        YeeAssemblyHelpers.CreateDefualtModule
                            (typeof(Yee.Section.Module).Assembly)
                    }),
            });

var swagger = YeeAssemblyHelpers.CreateDefualtModule
    (typeof(Yee.Swagger.Module).Assembly);

var builder = new YeeApplicationBuilder(args);

builder.Services.AddSingleton<NupkgStorage>();
builder.Services.AddSingleton<NupkgOptions>();
builder.Services.AddSingleton<YeeModuleStorage>();
builder.Services
    .AddSingleton<IYeeProvider<BaseYeeModule>, NupkgYeeProvider>();
builder.Services.AddSingleton<YeeViewManager>();
builder.Services.AddSingleton<BaseYeeModule>(example);
builder.Services.AddSingleton<BaseYeeModule>(swagger);

builder.Build();
