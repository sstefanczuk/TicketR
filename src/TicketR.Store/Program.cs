using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;
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
            Configuration = configurationBuilder.Build();

            ConfigurRabbitMq(services);
            RegisterRabbitMQ(services);
            RegisterRabbitMQHandlers(services);

            Console.WriteLine("Hello World!");
        }

        public static IConfiguration Configuration { get; private set; }

        public static void ConfigurRabbitMq(IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"]
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                return new RabbitMQConnection(factory);
            });
        }

        public static void RegisterRabbitMQ(IServiceCollection services)
        {
            var queueName = Configuration.GetSection("SubscriptionClientName").Value;
            services.AddSingleton<IRabbitMQSubscriptionManager, RabbitMQSubscriptionManager>();
            services.AddSingleton<IRabbitMQMessageBroker, RabbitMQMessageBroker>(sp =>
            {
                var rabbitMqConnection = sp.GetRequiredService<IRabbitMQConnection>();
                var rabbitMqSubscriptionManager = sp.GetRequiredService<IRabbitMQSubscriptionManager>();
                var serviceScopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitMQMessageBroker(rabbitMqConnection, rabbitMqSubscriptionManager, serviceScopeFactory, queueName);
            });

            services.AddTransient<ProductPriceChangedMessageHandler>(sp =>
            {
                var storeService = sp.GetRequiredService<IStoreService>();
                return new ProductPriceChangedMessageHandler(storeService);
            });
        }

        private static void RegisterRabbitMQHandlers(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var messageBroker = serviceProvider.GetService<IRabbitMQMessageBroker>();

            messageBroker.Subscribe<ProductPriceChangedMessage, ProductPriceChangedMessageHandler>();
        }
    }
}
