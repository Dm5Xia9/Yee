using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Page.Repositories;
using Yee.Page.Services;
using Yee.Web.Extensions;

namespace Yee.Page
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddScoped<PageDbContext>();
                    p.AddSingleton<PageCollection>();
                    p.AddScoped<PageRepository>();
                });
        }
    }
}
