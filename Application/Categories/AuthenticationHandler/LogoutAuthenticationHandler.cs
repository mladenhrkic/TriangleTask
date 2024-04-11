using Application.Categories.Authentication;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.AuthenticationHandler
{
    public class LogoutAuthenticationHandler(IUserAuthenticationService userAuthenticationService) : 
        IRequestHandler<LogoutAuthentication>
    {
        private readonly IUserAuthenticationService _userAuthenticationService = userAuthenticationService;

        public async Task Handle(LogoutAuthentication request, CancellationToken cancellationToken)
        {
            await _userAuthenticationService.LogoutAsync();
        }
    }
}