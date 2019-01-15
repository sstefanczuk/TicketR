using System;
using System.Threading.Tasks;
using TicketR.Cart.Message;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;

namespace TicketR.Cart.MessageHandlers
{
    public class ProductPriceChangedMessageHandler : IRabbitMQMessageHandler<ProductPriceChangedMessage>
    {
        public async Task Handle(ProductPriceChangedMessage message)
        {
            //Business Logic

            await Task.CompletedTask;
        }
    }
}
