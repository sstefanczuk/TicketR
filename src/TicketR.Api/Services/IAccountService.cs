using RestEase;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TicketR.Common.Models;

namespace TicketR.Api.Services
{
    public interface IAccountService
    {
        [AllowAnyStatusCode]
        [Get("api/heartbeat")]
        Task<HeartbeatDetails> HeartbeatAsync();

        [AllowAnyStatusCode]
        [Get("api/login")]
        Task<JwtSecurityToken> LoginAsync();

        [AllowAnyStatusCode]
        [Get("api/register")]
        Task<List<string>> RegisterAsync();

        [AllowAnyStatusCode]
        [Get("api/forgotpassword")]
        Task<List<string>> ForgotPasswordAsync();
    }
}