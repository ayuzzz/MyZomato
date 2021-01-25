using CommonUtilities.Abstractions;
using CommonUtilities.ServiceBus;
using CommonUtilities.ServiceBus.Abstractions;
using Microsoft.Extensions.Configuration;
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

        public static  IServiceCollection AddServiceBusConfiguraion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus, EventBus>();
            services.AddSingleton<IEventService, EventService>();
            services.AddSingleton<IServicebusConnectionFactory, ServicebusConnectionFactory>();
            ServicebusConnectionFactory.SetServicebusConnectionProperties(configuration);

            return services;
        }
    }
}
