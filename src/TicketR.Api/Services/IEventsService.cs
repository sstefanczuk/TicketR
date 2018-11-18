using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketR.Api.Services
{
    public interface IEventsService
    {
        [AllowAnyStatusCode]
        [Get("events")]
        Task<List<string>> GetEventsAsync();
    }
}