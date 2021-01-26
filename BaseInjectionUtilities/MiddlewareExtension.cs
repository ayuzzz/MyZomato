using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseInjectionUtilities
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder SwaggerExtension(this IApplicationBuilder app, string url, string name)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url, name);
            });

            return app;
        }

        public static IApplicationBuilder CorsExtension(this IApplicationBuilder app, string corsPolicyName)
        {
            app.UseCors(corsPolicyName);

            return app;
        }
    }
}
