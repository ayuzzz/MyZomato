using BaseInjectionUtilities;
using CommonUtilities;
using CommonUtilities.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using restaurantsquery.Repositories;
using restaurantsquery.Repositories.Abstractions;
using restaurantsquery.Services;
using restaurantsquery.Services.Abstractions;
using System;

namespace restaurantsquery
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
            
            services.AddSingleton<IRestaurantService, RestaurantService>();
            services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<ILocationRepository, LocationRepository>();

            ConfigureApplicationServices(services);
            services.AddSwaggerConfiguration("v1", "My Zomato", "Rerstaurant Service Api's")
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
