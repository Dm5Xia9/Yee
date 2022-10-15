using Ability.Core.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yee.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IDKEY = System.Int64;
using Yee.EntityFrameworkCore.Manager;
using Yee.EntityFrameworkCore.Abstractions;

namespace Ability.Core.Data
{
    public abstract class AbilityDbContext : DbContext, IYeeDbContext
    {
        private readonly string _schema;
        public AbilityDbContext(string schema, IDbContextOptionsProvider provider) : base(provider.GetOptions(schema))
        {
            _schema = schema;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(_schema);
            base.OnModelCreating(builder);
            builder.ProcessAbilityAnnotationAttributes(this);
        }

    }
}
