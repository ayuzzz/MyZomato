using BaseInjectionUtilities;
using CommonModels.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using orderscommand.Application.EventHandlers;
using orderscommand.Application.ServiceBus;
using orderscommand.Application.ServiceBus.Abstractions;
using orderscommand.Repositories;
using orderscommand.Repositories.Abstractions;
using orderscommand.Services;
using orderscommand.Services.Abstractions;
using orderscommand.Utility;
using orderscommand.Utility.Abstractions;
using System;
using System.Collections.Generic;

namespace orderscommand
{
    public class Startup:AppStartupBase
    {
        public Startup(IConfiguration configuration):base(configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<INewTransactionEventService, NewTransactionEventService>();
            services.AddSingleton<IOrderCreatedEventService, OrderCreatedEventService>();
            services.AddSingleton<IOrderStatusChangedService, OrderStatusChangedEventService>();
            services.AddSingleton<IEmailHelper, EmailHelper>();


            ConfigureApplicationServices(services, enableServiceBus: true);

            services.AddSwaggerConfiguration("v1", "My Zomato", "Orders service Api's")
                    .AddCorsPolicies("MyPolicy")
                    .ConfigureMassTransitForRabbitMq(Configuration, registerHandlers: new Dictionary<Type, Type>
                    {
                        [typeof(OrderCreatedEventHandler)] = typeof(OrderCreatedEvent),
                        [typeof(OrderStatusChangedEventHandler)] = typeof(OrderStatusChangedEvent)
                    });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SwaggerExtension("/swagger/v1/swagger.json", "MyZomato")
                .UseHttpsRedirection()
                .UseRouting()
                .CorsExtension("MyPolicy").UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });            
        }
    }
}
