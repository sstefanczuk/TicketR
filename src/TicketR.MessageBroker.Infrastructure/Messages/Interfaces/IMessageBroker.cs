using TicketR.MessageBroker.Infrastructure.Messages.Models;

namespace TicketR.MessageBroker.Infrastructure.Messages.Interfaces
{
    public interface IMessageBroker
    {
        void Publish(Message message);

        void Subscribe<TMessage, TMessageIntegrationHandler>()
            where TMessage : Message
            where TMessageIntegrationHandler : IMessageHandler<TMessage>;

        void UnSubscribe<TMessage, TMessageIntegrationHandler>()
            where TMessage : Message
            where TMessageIntegrationHandler : IMessageHandler<TMessage>;
    }
}
