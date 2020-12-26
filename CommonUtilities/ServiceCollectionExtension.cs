using CommonUtilities.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtilities
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommonUtilitiesLibrary(this IServiceCollection services)
        {
            services.AddSingleton<ISqlRepository, SqlRepository>();
            return services;
        }
    }
}
