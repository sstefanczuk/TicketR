using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketR.Common.Core.Abstract;

namespace TicketR.Common.Core
{
    public static class Extensions
    {
        public static void RegisterBus(this IServiceCollection services)
        {
            services.AddTransient<IBus, Bus>();
        }
    }
}
