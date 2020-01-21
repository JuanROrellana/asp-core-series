using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace api.Extensions
{
    public static class ServiceExtensions
    {
        
        //Configure Cors to Allow external client to connect to the api
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", 
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        //For Deployment
        public static void ConfigureIisIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => 
            {
 
            }); 
        }
    }
}