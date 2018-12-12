using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketR.Api.Services
{
    public interface IAccountService
    {
        [AllowAnyStatusCode]
        [Get("api/login")]
        Task<String> LoginAsync();

        [AllowAnyStatusCode]
        [Get("api/register")]
        Task<List<string>> RegisterAsync();

        [AllowAnyStatusCode]
        [Get("api/forgotpassword")]
        Task<List<string>> ForgotPasswordAsync();
    }
}