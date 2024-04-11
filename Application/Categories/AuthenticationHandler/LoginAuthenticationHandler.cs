using Application.Categories.Authentication;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.AuthenticationHandler
{
    public class LoginAuthenticationHandler(IUserAuthenticationService userAuthenticationService) :
        IRequestHandler<LoginAuthentication, Status>
    {
        private readonly IUserAuthenticationService _userAuthenticationService = userAuthenticationService;

        public async Task<Status> Handle(LoginAuthentication request, CancellationToken cancellationToken)
        {
            var model = new LoginModel
            {
                Username = request.Username,
                Password = request.Password
            };

            return await _userAuthenticationService.LoginAsync(model);
        }
    }
}