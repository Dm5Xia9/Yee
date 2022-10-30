using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.EntityFrameworkCore.FileStorage.Services;
using Yee.Extensions;
using Yee.Web.Extensions;

namespace Yee.EntityFrameworkCore.FileStorage
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddScoped<FileStorageManager>();
                    p.AddScoped<FileStorageDbContext>();
                })
                .AspPostBuild(p =>
                {

                });
        }
    }
}
