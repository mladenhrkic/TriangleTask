using Domain.Models;
using MediatR;

namespace Application.Categories.Authentication
{
    public class RegistrationAuthentication : IRequest<Status>
    {
        public RegistrationModel? RegistrationModel { get; set; }
    }
}
