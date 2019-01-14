using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using TicketR.Cart.Message;
using TicketR.Cart.MessageHandlers;
using TicketR.Cart.Services;
using TicketR.Cart.Services.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces;

namespace TicketR.Cart
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddScoped<ICartService, CartService>();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            Configuration = configurationBuilder.Build();

            ConfigurRabbitMq(services);
            RegisterRabbitMQ(services);
            ConfigureMessageBroker(services);


            var cartService = services.BuildServiceProvider().GetService<ICartService>();
            cartService.ChangePrice(1, 23m, 10m);

            Console.WriteLine("Hello World!");
        }

        public static IConfiguration Configuration { get; private set; }

        public static void ConfigurRabbitMq(IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"//Configuration["EventBusConnection"]
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
            var queueName = "koszyk_queue";//Configuration["SubscriptionClientName"];
            services.AddSingleton<IRabbitMQSubscriptionManager, RabbitMQSubscriptionManager>();
            services.AddSingleton<IRabbitMQMessageBroker, RabbitMQMessageBroker>(sp =>
            {
                var rabbitMqConnection = sp.GetRequiredService<IRabbitMQConnection>();
                var rabbitMqSubscriptionManager = sp.GetRequiredService<IRabbitMQSubscriptionManager>();
                var serviceScopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitMQMessageBroker(rabbitMqConnection, rabbitMqSubscriptionManager, serviceScopeFactory, queueName);
            });

            services.AddTransient<ProductPriceChangedMessageHandler>();
        }

        private static void ConfigureMessageBroker(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var messageBroker = serviceProvider.GetService<IRabbitMQMessageBroker>();

            messageBroker.Subscribe<ProductPriceChangedMessage, ProductPriceChangedMessageHandler>();
        }
    }
}
