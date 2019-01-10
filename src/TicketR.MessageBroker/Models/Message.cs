using System;

namespace TicketR.MessageBroker.Models
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
