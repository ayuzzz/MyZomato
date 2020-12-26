using CommonUtilities;
using CommonUtilities.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using restaurantsquerycommand.Repositories;
using restaurantsquerycommand.Repositories.Abstractions;
using restaurantsquerycommand.Services;
using restaurantsquerycommand.Services.Abstractions;
using System;

namespace restaurantsquerycommand
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonUtilitiesLibrary();
            services.AddControllers();
            services.AddSingleton<IRestaurantService, RestaurantService>();
            services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
            //services.Add(new ServiceDescriptor(typeof(ISqlRepository), new SqlRepository(Configuration)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyZomato",
                    Description = "MyZomato Api's"  
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyZomato");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
