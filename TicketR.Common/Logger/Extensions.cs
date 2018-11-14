using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace TicketR.Common.Logger
{
    public static class Extensions
    {
        public static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder, string appName = null) =>
            webHostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                if(string.IsNullOrEmpty(appName))
                    appName = context.Configuration.GetSection("applicationName").Value;

                loggerConfiguration.Enrich.FromLogContext()
                    .MinimumLevel.Is(LogEventLevel.Debug)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", appName);

                loggerConfiguration.WriteTo.File("log.txt", LogEventLevel.Debug);
            });
    }
}