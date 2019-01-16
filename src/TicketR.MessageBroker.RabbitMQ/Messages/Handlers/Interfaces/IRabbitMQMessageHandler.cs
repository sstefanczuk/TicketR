using System.Threading.Tasks;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;

namespace TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces
{
    public interface IRabbitMQMessageHandler<in TRabbitMQMessage>
        where TRabbitMQMessage : RabbitMQMessage
    {
        Task Handle(TRabbitMQMessage message);
    }
}
