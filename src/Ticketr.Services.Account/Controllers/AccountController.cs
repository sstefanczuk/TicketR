using AutoMapper;
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
using TicketR.Common.Models.Account;
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
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto credentials)
        {
            var user = await userManager.FindByEmailAsync(credentials.Email);
            if (user == null)
            {
                return new BadRequestObjectResult("User does not exists");
            }

            var result = await signInManager.PasswordSignInAsync(user, credentials.Password, true, false);
            if (result.Succeeded)
            {
                var claims = await jwtService.GetValidClaims(user);

                return Ok(jwtService.GenerateJwt(claims));
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IdentityResult> RegisterAsync([FromBody] RegisterDto registerModel)
        {
            var user = mapper.Map<AppUser>(registerModel);
            
            var result = await userManager.CreateAsync(user, registerModel.Password);
            var roleResult = await userManager.AddToRoleAsync(user, "Customer");
            return result;
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPasswordAsync() => Ok();
    }
}
