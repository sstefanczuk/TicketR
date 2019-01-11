using TicketR.MessageBroker.Integrations.Interfaces;
using TicketR.MessageBroker.Messages.Models;

namespace TicketR.MessageBroker.Messages.Interfaces
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
