using BaseInjectionUtilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using productquerycommand.Application.ServiceBus;
using productquerycommand.Application.ServiceBus.Abstractions;
using productquerycommand.Repositories;
using productquerycommand.Repositories.Abstractions;
using productquerycommand.Services;
using productquerycommand.Services.Abstractions;

namespace productquerycommand
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
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IOrderCreatedService, OrderCreatedEventService>();

            ConfigureApplicationServices(services, enableServiceBus: true);

            services.AddSwaggerConfiguration("v1", "My Zomato", "Product service Api's")
                    .AddCorsPolicies("MyPolicy")
                    .ConfigureMassTransitForRabbitMq(Configuration);
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
