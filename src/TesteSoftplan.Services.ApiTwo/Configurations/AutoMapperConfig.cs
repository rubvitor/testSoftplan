using System;
using AutoMapper;
using TesteSoftplan.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TesteSoftplan.Services.ApiTwo.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}