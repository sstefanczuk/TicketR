using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketR.Common.Models.Account;

namespace TicketR.Services.Account.Controllers
{
    [Route("api/")]
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<AuthData> LoginAsync([FromBody]LoginDto credentials) => await mediator.Send(credentials);


        [HttpPost("register")]
        public async Task<IdentityResult> RegisterAsync([FromBody]RegisterDto registerModel) => await mediator.Send(registerModel);


        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPasswordAsync() => Ok();
    }
}
