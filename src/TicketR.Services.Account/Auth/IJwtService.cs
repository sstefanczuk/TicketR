using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketR.Common.Models.Account;
using TicketR.Services.Account.Models;

namespace TicketR.Services.Account.Auth
{
    public interface IJwtService
    {
        Task<List<Claim>> GetValidClaims(AppUser appUser);
        AuthData GenerateJwt(List<Claim> claims);
    }
}