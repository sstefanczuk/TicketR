using System;
using System.Collections.Generic;
using TicketR.MessageBroker.Integrations.Interfaces;
using TicketR.MessageBroker.Messages.Models;
using TicketR.MessageBroker.Subscriptions.Models;

namespace TicketR.MessageBroker.Subscriptions.Managers.Interfaces
{
    public interface IMessageBrokerSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnMessageRemoved;

        void AddSubscription<T, TH>()
            where T : Message
            where TH : IIntegrationMessageHandler<T>;

        void RemoveSubscription<T, TH>()
            where T : Message
            where TH : IIntegrationMessageHandler<T>;

        bool HasSubscriptionsForEvent<T>() where T : Message;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<SubscriptionModel> GetHandlersForEvent<T>() where T : Message;
        IEnumerable<SubscriptionModel> GetHandlersForEvent(string eventName);
        string GetMessageKey<T>();
    }
}
