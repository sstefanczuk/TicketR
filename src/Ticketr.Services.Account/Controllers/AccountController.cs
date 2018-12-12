using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketR.Services.Account.Controllers
{
    [Route("api/")]
    public class AccountController : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync() => Ok();

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync() => Ok();

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPasswordAsync() => Ok();
    }
}
