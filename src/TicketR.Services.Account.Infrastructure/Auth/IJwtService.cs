using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketR.Services.Account.Infrastructure.Models;

namespace TicketR.Services.Account.Infrastructure.Auth
{
    public interface IJwtService
    {
        Task<List<Claim>> GetValidClaims(AppUser appUser);
        string GenerateJwt(List<Claim> claims);
    }
}