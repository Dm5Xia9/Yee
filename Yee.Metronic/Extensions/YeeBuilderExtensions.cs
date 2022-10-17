using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Metronic.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string KeyUseMetconic = "UseMetronic";
        public static YeeBuilder UseMetronic(this YeeBuilder builder)
        {
            builder.Add(KeyUseMetconic, p => { });

            return builder;
        }
    }
}
