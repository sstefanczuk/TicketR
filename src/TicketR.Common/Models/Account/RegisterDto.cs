using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TicketR.Common.Models.Account
{
    public class RegisterDto : IRequest<IdentityResult>
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}