using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore.Abstractions;
using Yee.Page.Models;

namespace Yee.Page
{
    public class PageDbContext : AbilityDbContext
    {
        public PageDbContext(IDbContextOptionsProvider provider) : base("YeePage", provider)
        {

        }


        public DbSet<YeePage> YeePages { get; set; }

        public DbSet<YeeComponentValues> YeeComponentValues { get; set; }

        public DbSet<YeeProperty> YeeProperties { get; set; }
        public DbSet<YeePropertyValue> YeePropertyValues { get; set; }

        public DbSet<YeeRoute> YeeRoutes { get; set; }
    }
}
