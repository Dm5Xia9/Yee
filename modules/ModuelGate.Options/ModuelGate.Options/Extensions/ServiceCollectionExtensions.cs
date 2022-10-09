using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlexOptions<T>(this IServiceCollection services)
        {
            services.AddScoped<IFlexOptions<T>>(p => p
                .GetRequiredService<FlexOptionsFactory>().Create<T>());

            return services;
        }
    }
}
