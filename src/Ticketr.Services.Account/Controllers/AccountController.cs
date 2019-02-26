using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketR.Common.Core.Abstract;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;

namespace TicketR.Services.Account.Controllers
{
    [Route("api/")]
    public class AccountController : Controller
    {
        private readonly IBus _bus;

        public AccountController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ApiResponse<AuthData>> LoginAsync([FromBody]LoginQuery credentials) => await _bus.RunQuery(credentials);


        [HttpPost("register")]
        public async Task<ApiResponse> RegisterAsync([FromBody]RegisterCommand registerModel) => await _bus.RunCommand(registerModel);


        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPasswordAsync() => Ok();
    }
}
