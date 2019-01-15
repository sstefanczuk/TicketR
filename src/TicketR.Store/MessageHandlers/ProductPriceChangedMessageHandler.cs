using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.Store.Messages;
using TicketR.Store.Services.Interfaces;

namespace TicketR.Store.MessageHandlers
{
    public class ProductPriceChangedMessageHandler : IRabbitMQMessageHandler<ProductPriceChangedMessage>
    {
        private readonly IStoreService _storeService;

        public ProductPriceChangedMessageHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task Handle(ProductPriceChangedMessage message)
        {
            _storeService.SavePrice(message);

            //Bussines Logic like update database etc.

            await Task.CompletedTask;
        }
    }
}
