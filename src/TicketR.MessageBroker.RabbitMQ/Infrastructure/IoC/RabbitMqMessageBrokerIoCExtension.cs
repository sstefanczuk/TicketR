using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TicketR.MessageBroker.Infrastructure.Subscriptions.Managers;
using TicketR.MessageBroker.Infrastructure.Subscriptions.Managers.Interfaces;

namespace TicketR.MessageBroker.RabbitMQ.Infrastructure.IoC
{
    public static class RabbitMqMessageBrokerIoCExtension
    {
        public static void AddRabbitMQ(IServiceCollection services)
        {
            services.AddSingleton<IMessageBrokerSubscriptionsManager, MessageBrokerSubscriptionsManager>();
        }
    }
}
