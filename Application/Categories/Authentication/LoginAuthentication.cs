using Domain.Models;
using MediatR;

namespace Application.Categories.Authentication
{
    public class LoginAuthentication : IRequest<Status>
    {
        public LoginModel? LoginModel { get; set; }
    }
}
