using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketR.Api.Services;
using TicketR.Common.Models;

namespace TicketR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        private readonly IEventsService eventsService;
        private readonly IAccountService accountService;

        public HeartbeatController(IEventsService eventsService, IAccountService accountService)
        {
            this.eventsService = eventsService;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> ServicesCheck()
            => Ok(new
            {
                EventsService = await eventsService.HeartbeatAsync(),
                AccountService = await accountService.HeartbeatAsync()
            });

    }
}