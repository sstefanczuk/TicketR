namespace TicketR.Cart.Services.Interfaces
{
    public interface ICartService
    {
        void ChangePrice(int productId, decimal newPrice, decimal oldPrice);
    }
}
