using System;
using System.Collections.Generic;
using System.Text;
using TicketR.Store.Messages;
using TicketR.Store.Services.Interfaces;

namespace TicketR.Store.Services
{
    public class StoreService : IStoreService
    {
        public void SavePrice(ProductPriceChangedMessage message)
        {
            Console.WriteLine(message.NewPrice);
        }
    }
}
