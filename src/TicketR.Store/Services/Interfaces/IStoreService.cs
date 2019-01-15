using System;
using System.Collections.Generic;
using System.Text;
using TicketR.Store.Messages;

namespace TicketR.Store.Services.Interfaces
{
    public interface IStoreService
    {
        void SavePrice(ProductPriceChangedMessage message);
    }
}
