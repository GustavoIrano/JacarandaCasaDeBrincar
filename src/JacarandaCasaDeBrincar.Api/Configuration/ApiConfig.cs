using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace JacarandaCasaDeBrincar.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Production",
                    builder =>
                    builder.WithMethods("GET")
                    .WithOrigins("https://example.ex")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader());
            });

            return services;
        }
    }
}
