using Ability.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Blog.Models;
using Yee.EntityFrameworkCore.Abstractions;

namespace Yee.Blog
{
    public class BlogDbContext : AbilityDbContext
    {
        public BlogDbContext(IDbContextOptionsProvider provider) : base("YeeBlog", provider)
        {
        }

        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
    }
}
