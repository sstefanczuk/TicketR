using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using TicketR.Koszyk.Services;
using TicketR.Koszyk.Services.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces;

namespace TicketR.Koszyk
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddScoped<ICartService, CartService>();

            ConfigurRabbitMq(services);
            RegisterRabbitMQ(services);

            Console.WriteLine("Hello World!");
        }

        public static IConfiguration Configuration { get; }

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
            var subscriptionClientName = Configuration["SubscriptionClientName"];

            services.AddSingleton<IRabbitMQSubscriptionManager, RabbitMQSubscriptionManager>();
            services.AddSingleton<IRabbitMQMessageBroker, RabbitMQMessageBroker>(sp =>
            {
                var rabbitMqConnection = sp.GetRequiredService<IRabbitMQConnection>();
                var rabbitMqSubscriptionManager = sp.GetRequiredService<IRabbitMQSubscriptionManager>();
                return new RabbitMQMessageBroker(rabbitMqConnection);
            });
        }
    }
}
