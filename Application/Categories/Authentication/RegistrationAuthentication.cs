using Domain.Models;
using MediatR;

namespace Application.Categories.Authentication
{
    public class RegistrationAuthentication : IRequest<Status>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? Role { get; set; }
    }
}
