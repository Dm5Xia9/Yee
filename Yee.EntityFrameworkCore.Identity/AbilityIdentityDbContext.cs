using Ability.Core.Data;
using Ability.Core.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.EntityFrameworkCore.Abstractions;
using Yee.EntityFrameworkCore.Manager;
using IDKEY = System.Guid;


namespace Yee.EntityFrameworkCore.Identity
{
    public class AbilityIdentityDbContext : IdentityDbContext<AbilityUser, AbilityRole, IDKEY, AbilityUserClaim, AbilityUserRole, AbilityUserLogin, AbilityRoleClaim, AbilityUserToken>, IYeeDbContext
    {
        public AbilityIdentityDbContext(IDbContextOptionsProvider provider) : 
            base(provider.GetOptions("Identity"))
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Identity");
            base.OnModelCreating(builder);
            builder.ProcessAbilityAnnotationAttributes(this);
            ConfigureIdentityTables(builder);
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

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
