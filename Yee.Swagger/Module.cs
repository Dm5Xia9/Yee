using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Extensions;
using Yee.Swagger.Middlewares;
using Yee.Web.Extensions;

namespace Yee.Swagger
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddEndpointsApiExplorer();
                    p.AddSwaggerGen();
                })
                .AspConfigure(p =>
                {
                    p.AddFirst(new MiddleSwagger());
                });
        }
    }
}
