using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseInjectionUtilities
{
    public class AppStartupBase
    {
        private IConfiguration _configuration;

        public AppStartupBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureApplicationServices(IServiceCollection services, bool enableServiceBus = false)
        {
            services.AddCommonUtilitiesLibrary()
                    .AddMvcCore()
                    .AddApiExplorer();

            if (enableServiceBus)
                services.AddServiceBusConfiguration(_configuration);
        }

        public void ConfigureApplication(IApplicationBuilder app)
        {

        }
    }
}
