using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Ant.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string KeyUseAntDesign = "UseAntDesign";
        public static YeeBuilder UseAntDesign(this YeeBuilder builder)
        {
            builder.Add(KeyUseAntDesign, p => { });

            return builder;
        }
    }
}
