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
            var model = new RegistrationModel
            {
                Name = request.Name,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Role = request.Role
            };

            return await userRegistrationService.RegistrationAsync(model);
        }
    }
}