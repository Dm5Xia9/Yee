using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Extensions;
using Yee.Section.Base;

namespace Yee.Admin.Swagger
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .YeeAdminCompose(p =>
                {
                    p.Navigations.Add(new NavMenuItem
                    {
                        Title = "Swagger",
                        Link = "/swagger"
                    });
                });
        }
    }
}
