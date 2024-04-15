using Domain.Models;

namespace Domain.Abstractions
{
    public interface IUserRegistrationService
    {
        Task<Status> RegistrationAsync(RegistrationModel model);
    }
}
