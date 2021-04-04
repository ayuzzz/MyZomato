using BaseInjectionUtilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using productquery.Application.ServiceBus;
using productquery.Application.ServiceBus.Abstractions;
using productquery.Repositories;
using productquery.Repositories.Abstractions;
using productquery.Services;
using productquery.Services.Abstractions;

namespace productquery
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
            

            ConfigureApplicationServices(services);

            services.AddSwaggerConfiguration("v1", "My Zomato", "Product service Api's")
                    .AddCorsPolicies("MyPolicy");

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
