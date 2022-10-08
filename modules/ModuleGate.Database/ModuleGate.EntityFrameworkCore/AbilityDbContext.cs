using Ability.Core.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IDKEY = System.Int64;

namespace Ability.Core.Data
{
    public abstract class AbilityDbContext : IdentityDbContext<AbilityUser, AbilityRole, IDKEY, AbilityUserClaim, AbilityUserRole, AbilityUserLogin, AbilityRoleClaim, AbilityUserToken>, 
        IDataProtectionKeyContext
    {
        public AbilityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ProcessAbilityAnnotationAttributes(this);
            ConfigureIdentityTables(builder);
        }

        private void ConfigureIdentityTables(ModelBuilder builder)
        {
            builder.Entity<AbilityUser>().ToTable("Users");
            builder.Entity<AbilityRole>().ToTable("Roles");
            builder.Entity<AbilityUserRole>().ToTable("UserRoles");
            builder.Entity<AbilityUserClaim>().ToTable("UserClaims");
            builder.Entity<AbilityUserLogin>().ToTable("UserLogins");
            builder.Entity<AbilityRoleClaim>().ToTable("RoleClaims");
            builder.Entity<AbilityUserToken>().ToTable("UserTokens");

            // ASP .NET Core 1.1 compatibility:

            builder.Entity<AbilityUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AbilityUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AbilityUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
