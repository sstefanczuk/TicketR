using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TicketR.Services.Account.Data;
using TicketR.Services.Account.Models;
using Microsoft.EntityFrameworkCore;
using TicketR.Services.Account.Auth;
using System.Reflection;
using MediatR;

namespace TicketR.Services.Account.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var x = configuration.GetConnectionString("AccountConnection");

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Testing123";
            var connString = $"Data Source={hostname};Initial Catalog=KontenaAspnetCore;User ID=sa;Password={password};";
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddDbContext<AccountDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("AccountConnection")));
        }      

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
