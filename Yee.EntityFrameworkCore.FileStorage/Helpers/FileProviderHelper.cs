using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.EntityFrameworkCore.FileStorage.Helpers
{
    public static class FileProviderHelper
    {
        public static void AddStaticFileProvider(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var webHost = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();


            //webHost.WebRootFileProvider = new CompositeFileProvider(webHost.WebRootFileProvider, );
        }
    }
}
