using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketR.MessageBroker.Infrastructure.Messages.Models;

namespace TicketR.MessageBroker.Integrations.Interfaces
{
    public interface IMessageHandler<in TMessage> where TMessage : Message
    {
        Task Handle(TMessage message);
    }
}
