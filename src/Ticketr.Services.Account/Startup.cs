using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketR.Common.Middleware;
using TicketR.Services.Account.Data;
using TicketR.Services.Account.Extensions;
using TicketR.Services.Account.Models;
using TicketR.Common.Auth;
using TicketR.Common.Core;

namespace TicketR.Services.Account
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddIdentity(Configuration);
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AccountDbContext>()
                .AddDefaultTokenProviders();
            services.AddJwtSecurity(Configuration);
            services.AddMediatr();
            services.RegisterBus();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AccountDbContext dbContext)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseAuthentication();
            app.UseMvc();
            dbContext.Database.EnsureCreated();
        }
    }
}
