using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Base;

namespace Yee.Admin.Services
{
    public class AdminCompose
    {
        public AdminCompose()
        {
            Navigations = new List<NavMenuItem>();
            AssembliesForAdminLayout = new List<Assembly>();
        }

        public List<NavMenuItem> Navigations { get; init; }

        public List<Assembly> AssembliesForAdminLayout { get; init; }
    }

}
