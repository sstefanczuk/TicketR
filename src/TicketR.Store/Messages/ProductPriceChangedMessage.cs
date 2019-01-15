using System;
using System.Collections.Generic;
using System.Text;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;

namespace TicketR.Store.Messages
{
    public class ProductPriceChangedMessage : RabbitMQMessage
    {
        public int ProductId { get; }

        public decimal NewPrice { get; }

        public decimal OldPrice { get; }

        public ProductPriceChangedMessage(int productId, decimal newPrice, decimal oldPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
            OldPrice = oldPrice;
        }
    }
}
