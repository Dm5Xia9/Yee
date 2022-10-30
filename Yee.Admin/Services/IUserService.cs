using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Admin.ViewModels.Users;

namespace Yee.Admin.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUser(UserForm userForm);
    }
}
