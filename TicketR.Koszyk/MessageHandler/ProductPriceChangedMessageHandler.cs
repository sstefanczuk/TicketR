using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketR.Koszyk.Message;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;

namespace TicketR.Koszyk.MessageHandler
{
    public class ProductPriceChangedMessageHandler : IRabbitMQMessageHandler<ProductPriceChangedMessage>
    {
        public async Task Handle(ProductPriceChangedMessage message)
        {
            Console.WriteLine(message.NewPrice);
            await Task.CompletedTask;
        }
    }
}
