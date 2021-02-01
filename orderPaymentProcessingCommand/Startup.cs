using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseInjectionUtilities;
using CommonModels.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using orderPaymentProcessingCommand.Application.EventHandlers;

namespace orderPaymentProcessingCommand
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
            ConfigureApplicationServices(services, enableServiceBus: true);

            services.AddSwaggerConfiguration("v1", "My Zomato", "Order-Transaction command Api's")
                    .AddCorsPolicies("MyPolicy")
                    .ConfigureMassTransitForRabbitMq(Configuration, registerHandlers: new Dictionary<Type, Type>
                    {
                        [typeof(NewTransactionEventHandler)] = typeof(NewTransactionEvent),
                        [typeof(PaymentStatusChangedEventHandler)] = typeof(PaymentStatusChangedEvent)
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
