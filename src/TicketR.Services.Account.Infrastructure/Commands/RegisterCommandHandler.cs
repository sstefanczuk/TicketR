using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TicketR.Common.Models.Account;
using TicketR.Services.Account.Infrastructure.Models;

namespace TicketR.Services.Account.Infrastructure.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterDto, IdentityResult>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public RegisterCommandHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IdentityResult> Handle(RegisterDto request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<AppUser>(request);
            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded) await userManager.AddToRoleAsync(user, "Customer");

            return result;
        }
    }
}
