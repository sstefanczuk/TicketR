using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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
    }
}