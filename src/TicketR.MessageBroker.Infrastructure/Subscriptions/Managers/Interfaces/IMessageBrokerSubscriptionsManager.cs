using System;
using System.Collections.Generic;
using TicketR.MessageBroker.Infrastructure.Messages.Interfaces;
using TicketR.MessageBroker.Infrastructure.Messages.Models;
using TicketR.MessageBroker.Infrastructure.Subscriptions.Models;

namespace TicketR.MessageBroker.Infrastructure.Subscriptions.Managers.Interfaces
{
    public interface IMessageBrokerSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnMessageRemoved;

        void AddSubscription<T, TH>()
            where T : Message
            where TH : IMessageHandler<T>;

        void RemoveSubscription<T, TH>()
            where T : Message
            where TH : IMessageHandler<T>;

        bool HasSubscriptionsForEvent<T>() where T : Message;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<SubscriptionModel> GetHandlersForEvent<T>() where T : Message;
        IEnumerable<SubscriptionModel> GetHandlersForEvent(string eventName);
        string GetMessageKey<T>();
    }
}
