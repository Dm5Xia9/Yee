using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Admin.ViewModels.Roles;
using Yee.Admin.ViewModels.Users;

namespace Yee.Admin.Services
{
    public interface IRoleService
    {
        public Task CreateRole(RoleForm roleForm);
    }
}
