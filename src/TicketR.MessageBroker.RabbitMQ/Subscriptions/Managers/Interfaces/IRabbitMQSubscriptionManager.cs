using System;
using System.Collections.Generic;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Models;

namespace TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces
{
    public interface IRabbitMQSubscriptionManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnMessageRemoved;

        void AddSubscription<T, TH>()
            where T : RabbitMQMessage
            where TH : IRabbitMQMessageHandler<T>;

        void RemoveSubscription<T, TH>()
            where T : RabbitMQMessage
            where TH : IRabbitMQMessageHandler<T>;

        bool HasSubscriptionsForMessage<T>() where T : RabbitMQMessage;
        bool HasSubscriptionsForMessage(string messageName);
        Type GetEventTypeByName(string messageName);
        void Clear();
        IEnumerable<RabbitMQSubscriptionModel> GetHandlersForMessage<T>() where T : RabbitMQMessage;
        IEnumerable<RabbitMQSubscriptionModel> GetHandlersForMessage(string messageName);
        string GetMessageKey<T>();
    }
}
