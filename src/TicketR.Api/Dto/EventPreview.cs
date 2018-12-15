using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketR.Api.Dto
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
