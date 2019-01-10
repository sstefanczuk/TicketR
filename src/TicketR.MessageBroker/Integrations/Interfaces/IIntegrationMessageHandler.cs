using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketR.MessageBroker.Models;

namespace TicketR.MessageBroker.Integrations.Interfaces
{
    public interface IIntegrationMessageHandler<in TMessage> where TMessage : Message
    {
        Task Handle(TMessage message);
    }
}
