using System;
using TicketR.Common.Enums;

namespace TicketR.Common.Models.Events
{
    public class EventPreview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public EventCategory Category { get; set; }
    }
}
