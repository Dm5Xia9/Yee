using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.FileStorage.Services;

namespace Yee.FileStorage
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddSingleton<FileStorageService>();
                })
                .AspPostBuild(p =>
                {
                    var webHost = p.GetRequiredService<IWebHostEnvironment>();

                    var storage = p.GetRequiredService<FileStorageService>();

                    webHost.WebRootFileProvider =
                        new CompositeFileProvider(webHost.WebRootFileProvider,
                        new PhysicalFileProvider(storage.GetRootPath()));
                });
        }
    }
}
