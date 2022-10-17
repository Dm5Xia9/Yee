using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Navigation;

namespace Yee.Admin.Abstractions
{

    public interface INavPatch
    {
        public void Patch(List<NavMenuItem> navMenuItems);
    }
}
