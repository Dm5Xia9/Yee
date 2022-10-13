using Microsoft.Extensions.DependencyInjection;
using Yee.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;

namespace Yee.EntityFrameworkCore.Npgsql
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder.AspConfigureServices(p =>
            {
                p.AddScoped<IDbContextOptionsProvider, NpgsqlOptionsProvider>();
            });
        }
    }
}
