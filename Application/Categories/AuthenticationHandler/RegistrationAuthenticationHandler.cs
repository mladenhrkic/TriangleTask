using Application.Categories.Authentication;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.AuthenticationHandler
{
    public class RegistrationAuthenticationHandler(IUserRegistrationService userRegistrationService) :
        IRequestHandler<RegistrationAuthentication, Status>
    {
        public async Task<Status> Handle(RegistrationAuthentication request, CancellationToken cancellationToken)
        {
            request.RegistrationModel ??= new RegistrationModel();
            return await userRegistrationService.RegistrationAsync(request.RegistrationModel);
        }
    }
}