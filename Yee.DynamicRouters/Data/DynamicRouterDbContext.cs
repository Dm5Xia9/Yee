using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.DynamicRouters.Models;
using Yee.EntityFrameworkCore.Abstractions;

namespace Yee.DynamicRouters.Data
{
    public class DynamicRouterDbContext : AbilityDbContext
    {
        public DynamicRouterDbContext(IDbContextOptionsProvider provider) : base("DynamicRouter", provider)
        {
        }

        public DbSet<YeeRoute> YeeRoutes { get; set; }
    }
}
