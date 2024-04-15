using Application.Categories.Authentication;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.AuthenticationHandler
{
    public class LogoutAuthenticationHandler(IUserAuthenticationService userAuthenticationService) : 
        IRequestHandler<LogoutAuthentication>
    {
        public async Task Handle(LogoutAuthentication request, CancellationToken cancellationToken)
        {
            await userAuthenticationService.LogoutAsync();
        }
    }
}