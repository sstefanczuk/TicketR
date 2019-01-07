using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketR.Common.Models;
using TicketR.Common.Models.Account;
using TicketR.Services.Account.Infrastructure.Models;

namespace TicketR.Services.Account.Infrastructure.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AppUser, RegisterDto>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
