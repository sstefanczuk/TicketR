using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketR.Common.Models;

namespace TicketR.Api.Services
{
    public interface IEventsService
    {
        [AllowAnyStatusCode]
        [Get("api/heartbeat")]
        Task<HeartbeatDetails> HeartbeatAsync();

        [AllowAnyStatusCode]
        [Get("api/events")]
        Task<List<string>> GetEventsAsync();
    }
}