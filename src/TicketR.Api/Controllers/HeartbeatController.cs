using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var ht = new HttpClient();
            var x = await ht.GetAsync("http://localhost:5001/api/events/1");
            return Ok(new
            {
                DateTime = DateTime.Now.ToString("r"),
                Message = "Ok"
            });
        }
    }
}
