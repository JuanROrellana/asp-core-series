using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;

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
            services.Configure<IISOptions>(options => { });
        }

        //Add Logging
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //Add Database Connection and Repository
        public static void ConfigureMySqlContext(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var connectionString = configuration["mysqlconnection:connectionString"];
            serviceCollection.AddDbContextPool<RepositoryContext>(o => o.UseMySql(connectionString));
        }
        
    }
}