using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TicketR.Services.Events.Dto;

namespace TicketR.Services.Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEvents()
            => Ok(new List<string>
                {
                    "test 1",
                    "test 2"
                });

        [HttpGet, Route("{id:int}")]
        public IActionResult GetEvent(int id) => Ok(new EventDetails
        {
            Id = id,
            Title = "Metallica",
            Subtitle = "WorldWired Tour",
            Date = new System.DateTime(2018, 11, 20),
            Category = "Heavy Metal Concert",
            Description = "Metallica is an American thrash metal/heavy metal band. The band came together in Los Angeles in 1981 and helped to invent the thrash sub-genre of heavy metal. They are well known for many of their songs, including \"Master of Puppets\", \"The Unforgiven\", \"One\", \"Enter Sandman\", and \"Nothing Else Matters\". <br /> Since then, they have become one of metal's most popular and successful bands, and have sold over 100 million albums worldwide. The band's fifth album, Metallica, has sold over 21 million copies, making it the twenty-fifth biggest selling album of all time in America.",
            ImagePath = "https://image.ibb.co/iftwqA/metallica.png",
            TicketsPerClientLimit = 5,
            Location = new Location
            {
                Name = "Tauron Arena",
                City = "Cracow",
                Description = "Tauron Arena Kraków is the largest and one of most modern entertainment and sports venues in Poland. It allows to host a variety of sports events, including badminton, boxing, curling, acrobatic and artistic gymnastics, indoor football, hockey, basketball, track and field, figure skating, volleyball, handball, martial arts, extreme sports, tennis, table tennis, equestrian competitions and sports dancing competitions.<br /><br />The facility area has 61,434 m2, with maximum area of the arena court of 4 546 m2. The average capacity is 18,000 for concerts, and 15,000 for sport events, with maximum number of spectators being 22,000.",
                ImagePath = "https://ebilet-media.azureedge.net/media/26679/tak_kontakt_foto450.jpg",
                AddressLines = new string[]
                    {
                        "Tauron Arena",
                        "Stanisława Lema 7",
                        "31-571 Kraków"
                    },
                Phone = "12 349 11 02"
            },
            TicketsPools = new List<TicketsPool>
                {
                    new TicketsPool
                    {
                        Name = "Golden Circle",
                        Price = 119.99M,
                        AvailableTickets = 3,
                        TotalTickets = 50
                    },
                    new TicketsPool
                    {
                        Name = "Level A",
                        Price = 109.99M,
                        AvailableTickets = 26,
                        TotalTickets = 100
                    },
                    new TicketsPool
                    {
                        Name = "Level B",
                        Price = 99.99M,
                        AvailableTickets = 39,
                        TotalTickets = 120
                    },
                    new TicketsPool
                    {
                        Name = "Level C",
                        Price = 79.99M,
                        AvailableTickets = 112,
                        TotalTickets = 180
                    }
                }
        });
    }
}