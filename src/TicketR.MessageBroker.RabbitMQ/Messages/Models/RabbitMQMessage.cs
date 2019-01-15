using System;

namespace TicketR.MessageBroker.RabbitMQ.Messages.Models
{
    public class RabbitMQMessage
    {
        public RabbitMQMessage()
        {
            Id = Guid.NewGuid();
            CreationMessageDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreationMessageDate { get; }
    }
}
