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

//TOdyu
//страница со всеми страницами
//добавление возможности опубликовать страницу
//добавление возможности настроить права доступа на страницу
//прототипы-формы
//система контекста страница, в которой секции может получить полную информацию о других секциях на странице
//Layout-секция. Позволяет внутри себя выбрать другие секции
//наследуемая модель прототипов и секций, где возможно модифициаровать любую секцию,
//прототип или обработчик без влезания непосредственно в код исходного объекта

//админка как набор секций. Админка должан быть на 100% сформирована с помощью секций и прототипов (кроме редактора страницы)
//модульность через nuget, проверка и подготовка к релизу
//----------сделать до 27-29 числа--------------
//подготовка документации
//гайд по развертыванию, DockerFile
//расширения для vs добавляющее все необходимое для начала разработки и тестирования модулей


var section = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Section.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {

                    });

var sectionBase = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Section.Base.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        section
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
                            (typeof(Yee.FileStorage.Module).Assembly),


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

var models = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Admin.Models.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        example
                    });

var pageEngine = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Admin.PageEngine.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                        example
                    });

var cabaretWWWroot = YeeAssemblyHelpers.CreateDefualtModule
                    (typeof(Yee.Cabaret.CoreFrontLibraries.Module).Assembly)
                    .AddDeps(new List<BaseYeeModule>
                    {
                    });


var adminSwagger = YeeAssemblyHelpers.CreateDefualtModule
            (typeof(Yee.Admin.Swagger.Module).Assembly)
            .AddDeps(new List<BaseYeeModule>
            {
                example
            });

var swagger = YeeAssemblyHelpers.CreateDefualtModule
    (typeof(Yee.Swagger.Module).Assembly);



//var core = YeeAssemblyHelpers.CreateDefualtModule
//    (typeof(Yee.CoreLayout.Module).Assembly);

//var mvc = YeeAssemblyHelpers.CreateDefualtModule
//    (typeof(Yee.MVC.Module).Assembly)
//    .AddDeps(new List<BaseYeeModule>
//    {
//    });

//var dRouter = YeeAssemblyHelpers.CreateDefualtModule
//    (typeof(Yee.DynamicRouters.Module).Assembly)
//    .AddDeps(new List<BaseYeeModule>
//    {
//        mvc,
//        entityFramework
//    });


var builder = new YeeApplicationBuilder(args);

builder.Services.AddSingleton<NupkgStorage>();
builder.Services.AddSingleton<NupkgOptions>();
builder.Services.AddSingleton<YeeModuleStorage>();
builder.Services.AddScoped<NotFoundBuilder>();
builder.Services
    .AddSingleton<IYeeProvider<BaseYeeModule>, NupkgYeeProvider>();
builder.Services.AddSingleton<YeeViewManager>();
builder.Services.AddSingleton<BaseYeeModule>(adminSwagger);
builder.Services.AddSingleton<BaseYeeModule>(example);
builder.Services.AddSingleton<BaseYeeModule>(swagger);
//builder.Services.AddSingleton<BaseYeeModule>(core);
builder.Services.AddSingleton<BaseYeeModule>(cabaretSection);
builder.Services.AddSingleton<BaseYeeModule>(pageEngine);
builder.Services.AddSingleton<BaseYeeModule>(cabaretWWWroot);
builder.Services.AddSingleton<BaseYeeModule>(models);
builder.Services.AddSingleton<BaseYeeModule>(sectionBase);
//builder.Services.AddSingleton<BaseYeeModule>(dRouter);

builder.Build();
