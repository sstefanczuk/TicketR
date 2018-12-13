using System;
using System.Collections.Generic;

namespace TicketR.Api.Dto
{
    public class EventDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int TicketsPerClientLimit { get; set; }

        public IEnumerable<TicketsPool> TicketsPools { get; set; }
        public Location Location { get; set; }
    }
}
