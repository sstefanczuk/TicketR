using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketR.Common.Core.Abstract;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;
using TicketR.Common.Models.Exceptions;
using TicketR.Services.Account.Models;

namespace TicketR.Services.Account.Commands
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, ApiResponse>
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ApiResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpper()
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Customer");
                return new ApiResponse { Status = System.Net.HttpStatusCode.OK };
            }

            throw new BadRequestException(string.Join(",", result.Errors.Select(x => x.Description)));
        }
    }
}
