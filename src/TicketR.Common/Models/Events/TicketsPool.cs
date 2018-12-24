namespace TicketR.Common.Models.Events
{
    public class TicketsPool
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        public int TotalTickets { get; set; }
    }
}
