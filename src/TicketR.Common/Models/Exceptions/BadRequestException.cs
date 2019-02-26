using System;

namespace TicketR.Common.Models.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
