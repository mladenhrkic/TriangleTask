using Application.Categories.Authentication;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.AuthenticationHandler
{
    public class LoginAuthenticationHandler(IUserAuthenticationService userAuthenticationService) :
        IRequestHandler<LoginAuthentication, Status>
    {
        public async Task<Status> Handle(LoginAuthentication request, CancellationToken cancellationToken)
        {
            request.LoginModel ??= new LoginModel();
            return await userAuthenticationService.LoginAsync(request.LoginModel);
        }
    }
}