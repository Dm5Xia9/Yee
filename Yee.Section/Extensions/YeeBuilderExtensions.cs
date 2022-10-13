using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Section.Services;

namespace Yee.Section.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string KeyYeeSections = "YeeSections";

        public static YeeBuilder YeeSections(this YeeBuilder builder,
            Action<ProtoHandlerCollection> action)
        {
            builder.Add(KeyYeeSections, p =>
            {
                action((ProtoHandlerCollection)p);
            });

            return builder;
        }
    }
}
