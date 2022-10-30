using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Admin.Services;
using Yee.Section.Services;

namespace Yee.Admin.Extensions
{
    public static class YeeBuildExtensions
    {
        public const string KeyYeeAdminCompose = "YeeAdminCompose";

        public static YeeBuilder YeeAdminCompose(this YeeBuilder builder,
            Action<AdminCompose> action)
        {
            builder.Add(KeyYeeAdminCompose, p =>
            {
                action((AdminCompose)p);
            });

            return builder;
        }
    }
}
