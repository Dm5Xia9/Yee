using Ability.Core.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModuleGate.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IDKEY = System.Int64;

namespace Ability.Core.Data
{
    public abstract class AbilityDbContext : DbContext
    {
        public AbilityDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ProcessAbilityAnnotationAttributes(this);
        }

    }
}
