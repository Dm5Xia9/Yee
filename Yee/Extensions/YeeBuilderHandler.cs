using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Extensions
{
    public static class YeeBuilderHandler
    {
        public static bool Go(YeeBuilder builder, string key, object value)
        {
            if (builder.ContainsKey(key))
            {
                builder[key](value);
                return true;
            }

            return false;
        }
    }
}
