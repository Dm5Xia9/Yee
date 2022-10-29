using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.CMS.All
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            var a1 = typeof(Yee.Admin.Module);
            var a2 = typeof(Yee.Admin.Models.Module);
            var a3 = typeof(Yee.Admin.PageEngine.Module);
            var a4 = typeof(Yee.EntityFrameworkCore.Npgsql.Module);

        }
    }
}
