using Azure.Messaging.ServiceBus;
using ControlMesh.Database;
using ControlMesh.Repository;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ControlMesh.Host
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.Development.json");
            var config = configurationBuilder.Build();
            var aiOptions = new ApplicationInsightsServiceOptions();

            aiOptions.ConnectionString = Environment.GetEnvironmentVariable("instrumentationkey");
            services.AddApplicationInsightsTelemetry(aiOptions);
            services.RegisterDataServices();
            services.AddScoped<IMessageRepo, MessageRepo>();
            services.AddHostedService<AuditListener>();
            services.AddLogging(configure =>
            {
                configure.AddApplicationInsights();
                configure.AddConsole();
            });

            AddServiceBus(services, config);
        }

        private static void AddServiceBus(IServiceCollection services, IConfigurationRoot config)
        {
            if (!Environment.GetEnvironmentVariable("env_sbconnstr").IsNullOrEmpty())
            {
                services.AddScoped(x =>
                new ServiceBusClient(Environment.GetEnvironmentVariable("env_sbconnstr")));
            }
            else
            {
                services.AddScoped(x => new ServiceBusClient(config["ConnectionStrings:ServiceBusConnString"]));
            }
        }
    }
}