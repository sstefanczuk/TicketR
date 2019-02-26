using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;
using TicketR.Services.Account.Auth;
using TicketR.Services.Account.Models;

namespace TicketR.Services.Account.Commands
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ApiResponse<AuthData>>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJwtService jwtService;

        public LoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public async Task<ApiResponse<AuthData>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, request.Password, true, false);
                if (result.Succeeded)
                {
                    var claims = await jwtService.GetValidClaims(user);
                    return new ApiResponse<AuthData>
                    {
                        Content = jwtService.GenerateJwt(claims),
                        Status = System.Net.HttpStatusCode.OK,
                    };
                }
            }

            return new ApiResponse<AuthData>
            {
                Message = "Invalid username or password",
                Status = System.Net.HttpStatusCode.Unauthorized,
            };
        }
    }
}
