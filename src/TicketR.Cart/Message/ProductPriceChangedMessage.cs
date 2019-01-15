using TicketR.MessageBroker.RabbitMQ.Messages.Models;

namespace TicketR.Cart.Message
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
