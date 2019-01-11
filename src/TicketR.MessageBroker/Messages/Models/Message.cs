using System;

namespace TicketR.MessageBroker.Messages.Models
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}
