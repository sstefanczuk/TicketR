using System.Threading.Tasks;
using TicketR.MessageBroker.Infrastructure.Messages.Models;

namespace TicketR.MessageBroker.Infrastructure.Messages.Interfaces
{
    public interface IMessageHandler<in TMessage> where TMessage : Message
    {
        Task Handle(TMessage message);
    }
}
