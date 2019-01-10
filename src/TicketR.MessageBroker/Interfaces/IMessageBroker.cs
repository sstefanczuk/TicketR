using System;
using System.Collections.Generic;
using System.Text;
using TicketR.MessageBroker.Integrations.Interfaces;
using TicketR.MessageBroker.Models;

namespace TicketR.MessageBroker.Interfaces
{
    public interface IMessageBroker
    {
        void Publish(Message message);

        void Subscribe<TMessage, TMessageIntegrationHandler>()
            where TMessage : Message
            where TMessageIntegrationHandler : IIntegrationMessageHandler<TMessage>;

        void UnSubscribe<TMessage, TMessageIntegrationHandler>()
            where TMessage : Message
            where TMessageIntegrationHandler : IIntegrationMessageHandler<TMessage>;
    }
}
