using System;
using TesteSoftplan.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TesteSoftplan.Services.ApiOne.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}