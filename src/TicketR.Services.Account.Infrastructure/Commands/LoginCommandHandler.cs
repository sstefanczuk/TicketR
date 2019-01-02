using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;
using TicketR.Services.Account.Infrastructure.Auth;
using TicketR.Services.Account.Infrastructure.Models;
using Newtonsoft.Json;
using RestEase;

namespace TicketR.Services.Account.Infrastructure.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginDto, AuthData>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJwtService jwtService;

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public async Task<AuthData> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, request.Password, true, false);
                if (result.Succeeded)
                {
                    var claims = await jwtService.GetValidClaims(user);
                    return jwtService.GenerateJwt(claims);
                }
            }

            throw new UnauthorizedAccessException("dsa");
        }
    }
}
