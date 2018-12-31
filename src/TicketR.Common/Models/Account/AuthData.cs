using System;
using System.Collections.Generic;
using System.Text;

namespace TicketR.Common.Models.Account
{
    public class AuthData
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
