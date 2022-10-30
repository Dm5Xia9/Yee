using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Ant.Extensions;
using Yee.Starter.Shared;
using Yee.Web.Extensions;

namespace Yee.Starter
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .UseAntDesign()
                .WebApp(p =>
                {
                    p.AddLayout(typeof(MainLayout));
                });
        }
    }
}
