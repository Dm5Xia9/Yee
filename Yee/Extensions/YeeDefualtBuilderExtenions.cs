using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Services;

namespace Yee.Extensions
{
    public static class YeeDefualtBuilderExtenions
    {
        public static YeeBuilder AspConfigureServices(this YeeBuilder builder, 
            Action<IServiceCollection> action)
        {
            builder.Add(YeeBuilderTags.AspConfigureServices, p =>
            {
                action((IServiceCollection)p);
            });

            return builder;
        }

        public static YeeBuilder AspConfigureServices(this YeeBuilder builder,
        Action<IServiceCollection, YeeModuleManager> action)
        {
            builder.Add(YeeBuilderTags.AspConfigureServicesAndModules, p =>
            {
                var servicesAndModules = (ServiceCollectionAndModules)p;
                action(servicesAndModules.Services, servicesAndModules.Modules);
            });

            return builder;
        }

        public static YeeBuilder AspPostBuild(this YeeBuilder builder,
            Action<IServiceProvider> action)
        {
            builder.Add(YeeBuilderTags.AspPostBuild, p =>
            {
                action((IServiceProvider)p);
            });

            return builder;
        }

        public static YeeBuilder Deps(this YeeBuilder builder,
            Action<List<Assembly>> action)
        {
            builder.Add(YeeBuilderTags.Deps, p =>
            {
                action((List<Assembly>)p);
            });

            return builder;
        }

    }

    public class ServiceCollectionAndModules
    {
        public IServiceCollection Services { get; set; }
        public YeeModuleManager Modules { get; set; }
    }
}
