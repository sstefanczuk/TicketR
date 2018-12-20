namespace TicketR.Common.Models.Events
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string City { get; set; }
        public string[] AddressLines { get; set; }
        public string Phone { get; set; }
    }
}
