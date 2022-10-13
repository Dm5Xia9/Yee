using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Forms.SharpForms;
using Yee.MVC;

namespace Yee.Forms.Extensions
{
    public static class YeeBuilderExtensions
    {
        public const string KeyYeeForm = "YeeForm";

        public static YeeBuilder YeeForms(this YeeBuilder builder,
            Action<SharpFormCollection> action)
        {
            builder.Add(KeyYeeForm, p =>
            {
                action((SharpFormCollection)p);
            });

            return builder;
        }
    }
}
