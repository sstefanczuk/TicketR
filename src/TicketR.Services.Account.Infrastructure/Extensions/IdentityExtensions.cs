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
using TicketR.Services.Account.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TicketR.Services.Account.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var x = configuration.GetConnectionString("AccountConnection");

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Testing123";
            var connString = $"Data Source={hostname};Initial Catalog=KontenaAspnetCore;User ID=sa;Password={password};";

            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddDbContext<AccountDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("AccountConnection")));
            //services.adautomapper
        }

        public static void AddJwtSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtService, JwtService>();
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            var secretKey = configuration.GetSection("secretKey").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<JwtIssuerOptions>(o =>
            {
                o.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                o.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                o.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                o.TokenValidationParameters = tokenValidationParameters;
                o.SaveToken = true;
            });
        }
    }
}
