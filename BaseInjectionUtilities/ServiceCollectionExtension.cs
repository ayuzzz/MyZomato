using Automatonymous;
using CommonModels.Queues;
using CommonUtilities;
using CommonUtilities.Abstractions;
using CommonUtilities.ServiceBus;
using CommonUtilities.ServiceBus.Abstractions;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseInjectionUtilities
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommonUtilitiesLibrary(this IServiceCollection services)
        {
            services.AddSingleton<ISqlRepository, SqlRepository>();
            return services;
        }

        public static IServiceCollection AddServiceBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus, EventBus>();
            services.AddSingleton<IEventService, EventService>();
            services.AddSingleton<IServicebusConnectionFactory, ServicebusConnectionFactory>();
            ServicebusConnectionFactory.SetServicebusConnectionProperties(configuration);

            return services;
        }

        public static IServiceCollection ConfigureMassTransitForRabbitMq(this IServiceCollection services, IConfiguration configuration, Dictionary<Type, Type> registerHandlers = null)
        {

            if(registerHandlers != null)
            {
                services.AddMassTransit(x =>
                {
                    foreach (var handler in registerHandlers)
                    {
                        x.AddConsumers(handler.Key);

                        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                        {
                            cfg.Host($"rabbitmq://{configuration["ServiceBus:Hostname"]}");

                            cfg.ReceiveEndpoint(EventQueues.EventQueuePairs[handler.Value.Name], ep =>
                            {
                                ep.PrefetchCount = 16;
                                ep.UseMessageRetry(r => r.Interval(2, 100));

                                ep.ConfigureConsumer(provider, handler.Key);
                            });
                        }));
                    }
                });
            }
            else
            {
                services.AddMassTransit(x =>
                {
                    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host($"rabbitmq://{configuration["ServiceBus:Hostname"]}");
                    }));
                });
            }

            services.AddMassTransitHostedService();

            return services;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, string version, string title, string description)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = version,
                    Title = title,
                    Description = description
                });
            });

            return services;
        }

        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, string policyName)
        {
            services.AddCors(o => o.AddPolicy(policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            return services;
        }
    }
}
