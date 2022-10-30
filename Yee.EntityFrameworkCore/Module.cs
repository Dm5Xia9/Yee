using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.EntityFrameworkCore.Manager;
using Yee.Extensions;

namespace Yee.EntityFrameworkCore
{
    public class Module : IYeeModule
    {
        public void Build(YeeBuilder builder)
        {
            builder
                .AspConfigureServices(p =>
                {
                    p.AddScoped<YeeContextManager>();
                    p.AddSingleton<DbContextState>();
                    p.AddSingleton<DbContextFactory>();
                })
                .AspPostBuild(p =>
                {
                    using var scope = p.CreateScope();

                    var modulesContext = scope.ServiceProvider.GetRequiredService<YeeContextManager>();
                    var factory = scope.ServiceProvider.GetRequiredService<DbContextFactory>();
                    foreach (var node in modulesContext.NormalizeNodes)
                    {
                        factory.Create(node.ContextType);
                    }
                });
        }
    }
}
