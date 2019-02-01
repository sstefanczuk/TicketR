using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TicketR.Common.Core.Abstract;

namespace TicketR.Common.Models.Account
{
    public class RegisterCommand : ICommand<ApiResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}