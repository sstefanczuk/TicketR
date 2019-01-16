using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Models;
using TicketR.MessageBroker.RabbitMQ.Messages;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces;
using TicketR.Store.MessageHandlers;
using TicketR.Store.Messages;
using TicketR.Store.Services;
using TicketR.Store.Services.Interfaces;

namespace TicketR.Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddScoped<IStoreService, StoreService>();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            Configuration = configurationBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var rabbitOptions = Configuration.GetSection("RabbitConfig").Get<RabbitMQConnectionModel>();

            ConfigurRabbitMq(services, rabbitOptions);
            RegisterRabbitMQ(services, rabbitOptions);
            ConfigureRabbitMQHandlers(services);

            Console.WriteLine("Hello World!");
        }

        public static IConfiguration Configuration { get; private set; }

        public static void ConfigurRabbitMq(IServiceCollection services, RabbitMQConnectionModel connectionConfig)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = connectionConfig.RabbitHostName
                };

                if (!string.IsNullOrEmpty(connectionConfig.RabbitUserName))
                {
                    factory.UserName = connectionConfig.RabbitUserName;
                }

                if (!string.IsNullOrEmpty(connectionConfig.RabbitPassword))
                {
                    factory.Password = connectionConfig.RabbitPassword;
                }

                return new RabbitMQConnection(factory);
            });
        }

        public static void RegisterRabbitMQ(IServiceCollection services, RabbitMQConnectionModel connectionConfig)
        {
            services.AddSingleton<IRabbitMQSubscriptionManager, RabbitMQSubscriptionManager>();
            services.AddSingleton<IRabbitMQMessageBroker, RabbitMQMessageBroker>(sp =>
            {
                var rabbitMqConnection = sp.GetRequiredService<IRabbitMQConnection>();
                var rabbitMqSubscriptionManager = sp.GetRequiredService<IRabbitMQSubscriptionManager>();
                var serviceScopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitMQMessageBroker(rabbitMqConnection, rabbitMqSubscriptionManager, serviceScopeFactory, connectionConfig.RabbitServiceQueue);
            });
            services.AddTransient<ProductPriceChangedMessageHandler>();
        }

        private static void ConfigureRabbitMQHandlers(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var messageBroker = serviceProvider.GetService<IRabbitMQMessageBroker>();

            //services.AddTransient<ProductPriceChangedMessageHandler>();
            messageBroker.Subscribe<ProductPriceChangedMessage, ProductPriceChangedMessageHandler>();
        }
    }
}
