using AutoMapper;
using MediatR;
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
        private readonly IMediator mediator;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService, IMapper mapper, RoleManager<IdentityRole> roleManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<AuthData> LoginAsync([FromBody]LoginDto credentials)
        {
            var response = await mediator.Send<AuthData>(credentials);
            return response;
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
