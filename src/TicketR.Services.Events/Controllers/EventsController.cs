using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketR.Services.Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new List<string>
                {
                    "test 1",
                    "test 2"
                }
            );
        }
    }
}