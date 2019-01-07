using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TicketR.Api.Services;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;

namespace TicketR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.Values.ToList().SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

            using (var response = await this.accountService.RegisterAsync(registerDto))
            {
                var result = response.GetContent();
                if (result.Errors.Any()) return new BadRequestObjectResult(result.Errors.Select(x => x.Description));
            }

            return Ok();
        }

        [ProducesResponseType(typeof(AuthData), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.Values.ToList().SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

            using (var response = await this.accountService.LoginAsync(loginDto))
            {
                if (response.ResponseMessage.IsSuccessStatusCode) return Ok(response.GetContent());
            }

            return new BadRequestObjectResult(new List<string> { "Invalid username or password" });
        }
    }
}