using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketR.Common.Middleware;
using TicketR.Services.Account.Infrastructure.Data;
using TicketR.Services.Account.Infrastructure.Extensions;
using TicketR.Services.Account.Infrastructure.Models;

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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AccountDbContext dbContext)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMvc();

            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }
    }
}
