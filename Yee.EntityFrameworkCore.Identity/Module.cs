using Ability.Core.Data;
using Ability.Core.Internal;
using Ability.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;

namespace Yee.EntityFrameworkCore.Identity
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder.
                AspConfigureServices(p =>
                {
                    p.AddScoped<AbilityIdentityDbContext>();
                    p.AddIdentity<AbilityUser, AbilityRole>(options =>
                    {
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 6;
                        options.Stores.MaxLengthForKeys = 128;
                    })
                    .AddDefaultTokenProviders()
                    .AddUserStore<AbilityUserStore<AbilityIdentityDbContext, AbilityUser, AbilityRole>>()
                    .AddRoleStore<AbilityRoleStore<AbilityIdentityDbContext, AbilityUser, AbilityRole>>()
                    .AddUserManager<AbilityUserManager<AbilityUser>>()
                    .AddSignInManager<AbilitySignInManager<AbilityUser>>()
                    .AddRoleManager<AbilityRoleManager<AbilityUser, AbilityRole>>();
                });


        }
    }
}
