using TicketR.Cart.Message;
using TicketR.Cart.Services.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;

namespace TicketR.Cart.Services
{
    public class CartService : ICartService
    {
        private readonly IRabbitMQMessageBroker _messageBroker;

        public CartService(IRabbitMQMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public void ChangePrice(int productId, decimal newPrice, decimal oldPrice)
        {
            var message = new ProductPriceChangedMessage(1, 34m, 24m);

            for (int i = 0; i < 100; i++)
            {
                
                _messageBroker.Publish(message);
            }           
        }
    }
}
