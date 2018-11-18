using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketR.Api.Services;

namespace TicketR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        private readonly IEventsService eventsService;

        public HeartbeatController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var ht = new HttpClient();
            //var x = await ht.GetAsync("http://localhost:5001/api/events");
            var d = await this.eventsService.GetEventsAsync();
            return Ok(new
            {
                DateTime = DateTime.Now.ToString("r"),
                Message = "Ok"
            });
        }
    }
}
