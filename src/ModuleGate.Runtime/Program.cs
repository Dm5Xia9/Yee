using Microsoft.Extensions.FileProviders;
using ModuleGate;
using ModuleGate.Middlewares;
using ModuleGate.Runtime.App;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.Models;
using ModuleGate.Runtime.App.PackageProviders;
using System.Collections.Generic;
using System.Reflection;


var builder = MGRuntimeApplication.CreateBuilder(args);

//builder.AddModule("C:\\Users\\jackf\\Documents\\ModuleGate\\examples\\ModuleGate.DefualtExample\\" +
//    "bin\\Debug\\net6.0\\ModuleGate.DefualtExample.dll");
builder.AddProvider<NupkgPackageProvider>();
builder.Services.AddSingleton<StarterOptions>(new StarterOptions
{
    ModuleName = "ModuleGate.App.Starter",
    ModuleVersion = "0.0.4",
    NugetSource = "http://49.12.227.30:555/v3/index.json",
    //Source = "C:\\Users\\jackf\\Documents\\ModuleGate\\" +
    //    "runtime\\ModuleGate.App.Starter\\bin\\Debug\\net6.0" +
    //    "\\ModuleGate.App.Starter.dll",
    //Assembly = typeof(ModuleGate.App.Starter.Startup).Assembly
});

var mgapp = builder.Build();
mgapp.App.Run();

//var initializer = new ModuleInitializer(modules);

//var builder = WebApplication.CreateBuilder(args);

//builder.Environment.UseStaticWebAssetsFromAssemblies(builder.Configuration,
//    initializer.GetModuleAssemblies().ToArray());

//var fff = builder.Environment.WebRootFileProvider;
//initializer.ConfigureBuilder(builder);



//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
//initializer.DefualtConfigureServices(builder.Services);


//initializer.ConfigureServicesModules(builder.Services);

//var app = builder.Build();
//initializer.BuildModules(app.Services);
//var middleBuilder = new MiddlewareBuilder();
//middleBuilder.AddLast(new MiddleNotDevelopment());
//middleBuilder.AddLast(new MiddleStaticFiles());
//middleBuilder.AddLast(new MiddleRouting());
//middleBuilder.AddLast(new MiddleBlazor("/_Host"));
//initializer.ConfigureModules(middleBuilder);


//foreach(var middle in middleBuilder)
//{
//    middle.Next(app);
//}

//app.Run();
