using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace ControlMesh.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.Development.json");
            var config = configurationBuilder.Build();
            AddDataBase(services, config);
            return services;
        }

        private static void AddDataBase(IServiceCollection services, IConfigurationRoot config)
        {
            if (!Environment.GetEnvironmentVariable("env_dbconnstr").IsNullOrEmpty())
            {

                services.AddDbContext<ControlMeshDataContext>(x =>
                    x.UseSqlServer(Environment.GetEnvironmentVariable("env_dbconnstr")));
            }
            else
            {
                services.AddDbContext<ControlMeshDataContext>(x => x.UseSqlServer(config["ConnectionStrings:SQLConnString"]));
            }
        }
    }
}