using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketR.Common.Models;

namespace TicketR.Services.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
            => Ok(new HeartbeatDetails
            {
                DateTime = DateTime.Now.ToString("r"),
                Message = "Ok"
            });
    }
}
