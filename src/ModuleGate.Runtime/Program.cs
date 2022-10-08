using Microsoft.Extensions.FileProviders;
using ModuleGate;
using ModuleGate.Middlewares;
using ModuleGate.Runtime.App;
using ModuleGate.Runtime.App.Helpers;
using ModuleGate.Runtime.App.PackageProviders;
using System.Collections.Generic;
using System.Reflection;


var builder = MGRuntimeApplication.CreateBuilder(args);

builder.AddProvider(new DllPackageProvider());
builder.AddModule("C:\\Users\\jackf\\Documents\\ModuleGate\\modules\\ModuleGate.Database\\ModuleGate.EntityFrameworkCore\\" +
    "bin\\Debug\\net6.0\\ModuleGate.EntityFrameworkCore.dll");

builder.AddModule("C:\\Users\\jackf\\Documents\\ModuleGate\\modules\\ModuleGate.Database\\ModuleGate.EntityFrameworkCore.Npgsql\\" +
    "bin\\Debug\\net6.0\\ModuleGate.EntityFrameworkCore.Npgsql.dll");

builder.AddModule("C:\\Users\\jackf\\Documents\\ModuleGate\\examples\\ModuleGate.DefualtExample\\" +
    "bin\\Debug\\net6.0\\ModuleGate.DefualtExample.dll");


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
