using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Ability.Core.Models;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using IDKEY = System.Int64;
using Ability.Core.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;

namespace Ability.Core.Data
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddAbilityIdentity<TContext>(this IServiceCollection services, Action<IdentityOptions> setupAction = null)
            where TContext : DbContext, IDataProtectionKeyContext
        {
            InternalAddAbilityIdentity<TContext>(services, null, setupAction);
            return services;
        }

        public static void AddAbilityIdentity<TContext, TUserManager>(this IServiceCollection services, Action<IdentityOptions> setupAction = null)
            where TContext : DbContext, IDataProtectionKeyContext
        {
            InternalAddAbilityIdentity<TContext>(services, typeof(TUserManager), setupAction);
        }

        private static IServiceCollection InternalAddAbilityIdentity<TContext>(IServiceCollection services, Type userManagerType, Action<IdentityOptions> setupAction)
            where TContext : DbContext, IDataProtectionKeyContext
        {
            if (setupAction == null)
            {
                // Default Ability configuration
                setupAction = options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;

                    options.Stores.MaxLengthForKeys = 128;
                };
            }

            services.AddDataProtection().PersistKeysToDbContext<TContext>();
            services.AddTransient<IPrincipal>(provider => provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User);
            ReflectionTools.CallGenericStaticMethodForDbContextType<TContext>(typeof(IdentityExtensions), nameof(RegisterStores), new object[] { services, setupAction }, userManagerType);
            return services;
        }

        public static void ProcessAbilityAnnotationAttributes(this ModelBuilder builder, DbContext context)
        {
            var properties = context.GetType().GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var cur in properties)
            {
                var ptype = cur.PropertyType.GetTypeInfo();
                if (ptype.IsGenericType && ptype.GetGenericTypeDefinition().Equals(typeof(DbSet<>)))
                {
                    var entityType = ptype.GetGenericArguments().Single();
                    var columns = entityType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    ManyToManyJoinTableAttribute.CheckAttribute(builder, entityType, columns);
                    UniqueAttribute.CheckAttribute(builder, entityType, columns);
                }
            }
        }

        [Obfuscation(Exclude = true)]
        private static void RegisterStores<TContext, TUser, TRole, TUserManager>(IServiceCollection services, Action<IdentityOptions> setupAction)
            where TContext : AbilityDbContext
            where TUser : AbilityUser
            where TRole : AbilityRole
            where TUserManager : class
        {
            //services.AddAuthentication(delegate (AuthenticationOptions opt)
            //{
            //    opt.DefaultScheme = IdentityConstants.ApplicationScheme;
            //    opt.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //}).AddIdentityCookies(delegate {});

            //var config = AddAbilityIdentityCore<TUser>(services, delegate (IdentityOptions o)
            //{
            //    o.Stores.MaxLengthForKeys = 128;
            //    setupAction?.Invoke(o);
            //});

            //config
            //    .AddDefaultUI()
            //    .AddDefaultTokenProviders();

            var config = services.AddIdentity<TUser, TRole>(setupAction)
                .AddDefaultTokenProviders()
                .AddUserStore<Internal.AbilityUserStore<TContext, TUser, TRole>>()
                .AddRoleStore<Internal.AbilityRoleStore<TContext, TUser, TRole>>()
                .AddUserManager<TUserManager>()
                .AddSignInManager<AbilitySignInManager<TUser>>()
                .AddRoleManager<AbilityRoleManager<TUser, TRole>>();

            config
                .AddDefaultTokenProviders();
        }

        //public static IdentityBuilder AddAbilityIdentityCore<TUser>(IServiceCollection services, Action<IdentityOptions> setupAction) where TUser : class
        //{
        //    services.AddOptions().AddLogging();
        //    services.TryAddScoped<IUserValidator<TUser>, UserValidator<TUser>>();
        //    services.TryAddScoped<IPasswordValidator<TUser>, PasswordValidator<TUser>>();
        //    services.TryAddScoped<IPasswordHasher<TUser>, PasswordHasher<TUser>>();
        //    services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
        //    services.TryAddScoped<IUserConfirmation<TUser>, DefaultUserConfirmation<TUser>>();
        //    services.TryAddScoped<IdentityErrorDescriber>();
        //    services.TryAddScoped<IUserClaimsPrincipalFactory<TUser>, UserClaimsPrincipalFactory<TUser>>();
        //    services.TryAddScoped<AbilityUserManager<TUser>>();
        //    if (setupAction != null)
        //    {
        //        services.Configure(setupAction);
        //    }
        //    return new IdentityBuilder(typeof(TUser), services);
        //}

    }
}
