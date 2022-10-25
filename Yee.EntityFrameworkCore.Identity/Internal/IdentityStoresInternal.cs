using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ability.Core.Models;
using IDKEY = System.Guid;
using Ability.Core.Data;
using Yee.EntityFrameworkCore.Identity;

namespace Ability.Core.Internal
{
    internal class AbilityUserStore<TContext, TUser, TRole>
        : UserStore<TUser, TRole, TContext, IDKEY, AbilityUserClaim, AbilityUserRole, AbilityUserLogin, AbilityUserToken, AbilityRoleClaim>
        where TContext : AbilityIdentityDbContext
        where TUser : AbilityUser
        where TRole : AbilityRole
    {
        public AbilityUserStore(TContext context)
            : base(context)
        {
        }
        public AbilityUserStore(IIdentityDbContexFactory factory)
            : base((TContext)factory.CreateDbContext())
        {
        }

        protected override AbilityUserClaim CreateUserClaim(TUser user, Claim claim)
        {
            return new AbilityUserClaim()
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }

        protected override AbilityUserLogin CreateUserLogin(TUser user, UserLoginInfo login)
        {
            return new AbilityUserLogin()
            {
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName,
                ProviderKey = login.ProviderKey
            };
        }

        protected override AbilityUserRole CreateUserRole(TUser user, TRole role)
        {
            return new AbilityUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id,
            };
        }

        protected override AbilityUserToken CreateUserToken(TUser user, string loginProvider, string name, string value)
        {
            return new AbilityUserToken()
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }

    internal class AbilityRoleStore<TContext, TUser, TRole>
        : RoleStore<TRole, TContext, IDKEY, AbilityUserRole, AbilityRoleClaim>
        where TContext : AbilityIdentityDbContext
        where TUser : AbilityUser
        where TRole : AbilityRole
    {
        public AbilityRoleStore(TContext context)
            : base(context)
        {
        }
        public AbilityRoleStore(IIdentityDbContexFactory factory)
            : base((TContext)factory.CreateDbContext())
        {
        }

        protected override AbilityRoleClaim CreateRoleClaim(TRole role, Claim claim)
        {
            return new AbilityRoleClaim()
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }
    }

    public class StandardIdentityDbContexFactory : IIdentityDbContexFactory
    {
        IDbContextFactory<DbContext> factory;
        public StandardIdentityDbContexFactory(IDbContextFactory<DbContext> source)
        {
            factory = source;
        }
        public DbContext CreateDbContext()
        {
            return factory.CreateDbContext();
        }
    }
}
