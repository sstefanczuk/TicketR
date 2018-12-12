using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketR.Services.Account.Infrastructure.Data;
using TicketR.Services.Account.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace TicketR.Services.Account.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var x = configuration.GetConnectionString("AccountConnection");
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<AppUser>>();
            services.AddDbContext<AccountDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("AccountConnection")));
        }
    }
}
