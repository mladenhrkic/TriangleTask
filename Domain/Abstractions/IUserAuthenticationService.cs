using Domain.Models;

namespace Domain.Abstractions
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}
