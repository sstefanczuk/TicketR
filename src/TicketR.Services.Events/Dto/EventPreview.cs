using System;

namespace TicketR.Services.Events.Dto
{
    public class EventPreview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
