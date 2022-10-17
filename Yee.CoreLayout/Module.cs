﻿using Yee.Abstractions;
using Yee.Extensions;
using Yee.Web.Extensions;

namespace Yee.CoreLayout
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {

                })
                .WebApp(p =>
                {
                    p.AddRouter(typeof(App));
                });


        }
    }
}