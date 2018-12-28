using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketR.Api.Services;
using TicketR.Common.Models;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApplicationException("Model is invalid");
            }

            var response = await this.accountService.RegisterAsync(registerDto);
            var result = response.GetContent();

            if (result.Errors.Any()) return new BadRequestObjectResult(result.Errors.Select(x => x.Description));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApplicationException("Model is invalid");
            }

            var response = await this.accountService.LoginAsync(loginDto);

            if(response.ResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.StringContent);
            }

            return Unauthorized();
        }
    }
}