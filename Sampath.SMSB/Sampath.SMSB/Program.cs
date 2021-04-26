using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sampath.SMSB.ConsoleApp;
using System;
using System.IO;
using EventBusRabbitMQ;
using RabbitMQ.Client;
using Sampath.SMSB.Infrastructure.Repositories;
using Sampath.SMSB.Infrastructure.Repositories.Queries;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Interfaces;
using Sampath.SMSB.Services;

namespace Sampath.SMSB
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<Startup>().Run();
        }
        private static IServiceCollection ConfigureServices()
        {
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfigurationRoot>(configuration);
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
                {
                    factory.UserName = configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
                {
                    factory.Password = configuration["EventBus:Password"];
                }

                return new RabbitMQConnection(factory);
            });
           // services.AddSingleton<EventBusRabbitMQConsumer>();
            services.AddTransient<ICommandText, CommandText>();
            services.AddTransient<IInQueRepository, InQueRepository>();
            services.AddTransient<IRabbitMQService, RabbitMQService>();
            // IMPORTANT! Register our application entry point
            services.AddTransient<Startup>();
            return services;
        }
    }
}
