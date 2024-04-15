using Domain.Models;
using MediatR;

namespace Application.Categories.Authentication
{
    public class LoginAuthentication : IRequest<Status>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
