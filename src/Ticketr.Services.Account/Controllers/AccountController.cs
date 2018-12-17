using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketR.Common.Models;
using TicketR.Services.Account.Infrastructure.Auth;
using TicketR.Services.Account.Infrastructure.Models;

namespace TicketR.Services.Account.Controllers
{
    [Route("api/")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJwtService jwtService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<JwtSecurityToken> LoginAsync([FromBody]LoginDto credentials)
        {
            if (!ModelState.IsValid)
            {
                throw new ApplicationException("You need to provide username and password");
            }

            var result = await signInManager.PasswordSignInAsync(credentials.UserName, credentials.Password, true, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(credentials.UserName);
                var claims = await jwtService.GetValidClaims(user);

                return jwtService.GenerateJwt(claims);
            }
            throw new ApplicationException("Invalid username or password");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerModel)
        {
            return Ok();
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPasswordAsync() => Ok();
    }
}
