using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketR.Common.Enums;
using TicketR.Common.Models;
using TicketR.Common.Models.Events;

namespace TicketR.Api.Services
{
    public interface IEventsService
    {
        [AllowAnyStatusCode]
        [Get("api/heartbeat")]
        Task<HeartbeatDetails> HeartbeatAsync();

        [AllowAnyStatusCode]
        [Get("api/events")]
        Task<List<EventPreview>> GetEventsAsync([Query]EventCategory category);

        [AllowAnyStatusCode]
        [Get("api/events/{id}")]
        Task<EventDetails> GetEventAsync([Path] int id);
    }
}