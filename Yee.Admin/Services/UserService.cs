using Ability.Core.Data;
using Ability.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Admin.ViewModels.Users;

namespace Yee.Admin.Services
{
    public class UserService : IUserService
    {
        //AbilityUserManager<AbilityUser> _userManager;

        //public UserService(AbilityUserManager<AbilityUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        public async Task CreateUser(UserForm userForm)
        {
            //var user = GetUserFromForm(userForm);
            //await _userManager.CreateAsync(user, userForm.Password);
        }

        private AbilityUser GetUserFromForm(UserForm user)
        {
            return new AbilityUser
            {
                UserName = user.Username,
                Email = user.Email
            };
        }
    }
}
