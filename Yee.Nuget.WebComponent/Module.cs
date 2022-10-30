using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Ant.Extensions;

namespace Yee.Nuget.WebComponent
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder.
                UseAntDesign();
        }
    }
}
