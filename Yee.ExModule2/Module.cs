using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Web.Extensions;

namespace Yee.ExModule2
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .WebApp(p =>
                {
                    p.AddRouter(typeof(App));
                });
        }
    }
}
