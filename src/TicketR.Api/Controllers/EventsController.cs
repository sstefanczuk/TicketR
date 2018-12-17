using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketR.Api.Services;
using TicketR.Common.Enums;

namespace TicketR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery]EventCategory category)
            => Ok(await eventsService.GetEventsAsync(category));

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
            => Ok(await eventsService.GetEventAsync(id));
    }
}
