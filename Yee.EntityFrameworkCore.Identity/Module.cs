using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;

namespace Yee.EntityFrameworkCore.Identity
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder.
                AspConfigureServices(p =>
                {
                    p.AddScoped<AbilityIdentityDbContext>();
                });


        }
    }
}
