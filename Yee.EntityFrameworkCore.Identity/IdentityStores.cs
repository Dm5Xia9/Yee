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
using Microsoft.AspNetCore.Authentication;
using IDKEY = System.Int64;

namespace Ability.Core.Data
{
    public class AbilityUserManager<TUser> : UserManager<TUser> where TUser : class
    {
        public AbilityUserManager(IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<AbilityUserManager<TUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }

    public class AbilityRoleManager<TUser, TRole> : RoleManager<TRole>
        where TRole : AbilityRole
    {
        public AbilityRoleManager(IRoleStore<TRole> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }

    public class AbilitySignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        public AbilitySignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger, IAuthenticationSchemeProvider schemes) : 
            base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }
}