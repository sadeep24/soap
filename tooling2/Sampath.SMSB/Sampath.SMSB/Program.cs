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
using Sampath.SMSB.Services.Handlers.MessageHandlers;
using Sampath.SMSB.Infrastructure.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sampath.SMSB.Services.Handlers.Interfaces;

namespace Sampath.SMSB
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Create service collection and configure our services
            //var services = ConfigureServices();
            //// Generate a provider
            //var serviceProvider = services.BuildServiceProvider();

            //// Kick off our actual code
            //serviceProvider.GetService<Startup>().Run();
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Build configuration
                    configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                        .AddJsonFile("appsettings.json", false)
                        .Build();

                    // Add access to generic IConfigurationRoot
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
                    services.AddSingleton<SignalRConnection>();
                    services.AddTransient<ICommandText, CommandText>();
                    services.AddTransient<IInQueRepository, InQueRepository>();
                    services.AddTransient<IRabbitMQService, RabbitMQService>();
                    services.AddTransient<IMessageProcessorService, MessageProcessorService>();
                    services.AddTransient<ILoggerService, LoggerService>();

                    //services
                    services.AddTransient<IMiniStatementService, MiniStatementService>();
                    services.AddTransient<IMissedCallReloadService, MissedCallReloadService>();
                    services.AddTransient<IReloadUsingDefaultAccountService, ReloadUsingDefaultAccountService>();
                    services.AddTransient<IReloadUsingSpecificAccountService, ReloadUsingSpecificAccountService>();
                    services.AddTransient<ISettleCreditCardOutstandingBalanceService, SettleCreditCardOutstandingBalanceService>();
                    services.AddTransient<ISLTReloadBillPaymentService, SLTReloadBillPaymentService>();
                    services.AddTransient<IStopChequeService, StopChequeService>();
                    services.AddTransient<ITransferToOtherBankAccountService, TransferToOtherBankAccountService>();
                    services.AddTransient<ITransferToOtherSampathAccountService, TransferToOtherSampathAccountService>();
                    services.AddTransient<ITransferToOwnAccountService, TransferToOwnAccountService>();
                    services.AddTransient<IInquireChequeStatusService, InquireChequeStatusService>();
                    services.AddTransient<ICreditCardBalanceInquiryService, CreditCardBalanceInquiryService>();
                    services.AddTransient<IChangePasswordService, ChangePasswordService>();
                    services.AddTransient<IBillPaymentService, BillPaymentService>();
                    services.AddTransient<IBalanceInquiryService, BalanceInquiryService>();
                    services.AddTransient<ISMSService, SMSService>();
                    services.AddTransient<ITeleBankingService, TeleBankingService>();

                    //handlers
                    services.AddTransient<IBalanceInqueryHandler, BalanceInqueryHandler>();
                    services.AddTransient<IBillPaymentHandler, BillPaymentHandler>();
                    services.AddTransient<IChangePasswordHandler, ChangePasswordHandler>();
                    services.AddTransient<ICreditCardBalanceInquiryHandler, CreditCardBalanceInquiryHandler>();
                    services.AddTransient<IInquireChequeStatusHandler, InquireChequeStatusHandler>();
                    services.AddTransient<IMiniStatementHandler, MiniStatementHandler>();
                    services.AddTransient<IMissedCallReloadHandler, MissedCallReloadHandler>();
                    services.AddTransient<IReloadUsingDefaultAccountHandler, ReloadUsingDefaultAccountHandler>();
                    services.AddTransient<IReloadUsingSpecificAccount, ReloadUsingSpecificAccountHandler>();
                    services.AddTransient<ISettleCreditCardOutstandingBalanceHandler, SettleCreditCardOutstandingBalanceHandler>();
                    services.AddTransient<ISLTReloadBillPaymentHandler, SLTReloadBillPaymentHandler>();
                    services.AddTransient<IStopChequeHandler, StopChequeHandler>();
                    services.AddTransient<ITransferToOwnAccountHandler, TransferToOwnAccountHandler>();
                    services.AddTransient<ITransferToOtherBankAccountHandler, TransferToOtherBankAccountHandler>();
                    services.AddTransient<ITransferToOtherSampathAccountHandller, TransferToOtherSampathAccountHandller>();

                    //Repositories
                    services.AddTransient<IInQueRepository, InQueRepository>();
                    services.AddTransient<IOutQueRepository, OutQueRepository>();
                    services.AddTransient<ITransactionRepository, TransactionRepository>();
                    services.AddTransient<ISMSMTNRepository, SMSMTNRepository>();
                    // IMPORTANT! Register our application entry point

                    services.AddTransient<Startup>();
                })
                .ConfigureLogging(logBuilder =>
                {
                    logBuilder.SetMinimumLevel(LogLevel.Trace);
                    logBuilder.AddLog4Net("log4net.config");

                }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var myService = services.GetRequiredService<Startup>();
                    await myService.Run();
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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

            services.AddSingleton<SignalRConnection>();
            services.AddTransient<ICommandText, CommandText>();
            services.AddTransient<IInQueRepository, InQueRepository>();
            services.AddTransient<IRabbitMQService, RabbitMQService>();
            services.AddTransient<IMessageProcessorService, MessageProcessorService>();
            services.AddTransient<ILoggerService, LoggerService>();
            // IMPORTANT! Register our application entry point

            services.AddTransient<Startup>();
            return services;
        }
    }
}
