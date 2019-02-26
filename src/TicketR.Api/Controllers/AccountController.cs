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

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterCommand registerDto)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.Values.ToList().SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

            var response = await this.accountService.RegisterAsync(registerDto);
            
            if (response.IsSuccessStatusCode) return Ok();
            return new BadRequestObjectResult(response.Content.ReadAsStringAsync().Result);
        }

        [ProducesResponseType(typeof(AuthData), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginQuery loginDto)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState.Values.ToList().SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

            var response = await this.accountService.LoginAsync(loginDto);

            if (response.Status == HttpStatusCode.OK) return Ok(response.Content);
            return new BadRequestObjectResult("Invalid username or password");
        }
    }
}