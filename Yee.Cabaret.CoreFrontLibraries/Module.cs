using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Web.Extensions;

namespace Yee.Cabaret.CoreFrontLibraries
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .WebApp(p =>
                {
                    //p.AddStyle("css/cab_app.css");
                    //p.AddStyle("css/cab_main.css");
                    p.AddScript("js/cab_app.js");
                    p.AddScript("js/cab_main.js");
                });
        }
    }
}
