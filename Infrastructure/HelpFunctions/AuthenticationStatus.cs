using Domain.Models;

namespace Infrastructure.HelpFunctions
{
    public static class AuthenticationStatus
    {
        public static Status Get(int code, string message)
        {
            return new Status()
            {
                StatusCode = code,
                Message = message
            };
        }
    }
}