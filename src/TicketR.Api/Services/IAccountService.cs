using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        [Post("api/login")]
        Task<JwtSecurityToken> LoginAsync();

        [Post("api/register")]
        [Produces(typeof(IdentityResult))]
        Task<Response<IdentityResult>> RegisterAsync([Body]RegisterDto registerDto);

        [AllowAnyStatusCode]
        [Post("api/forgotpassword")]
        Task<List<string>> ForgotPasswordAsync();
    }
}