using Domain.Abstractions;
using Domain.Models;
using Infrastructure.HelpFunctions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Repositories
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> singInManager,
            UserManager<ApplicationUser> userManager)
        {
            _singInManager = singInManager;
            _userManager = userManager;
        }

        public async Task<Status> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return AuthenticationStatus.Get(0, "Invalid Username");
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return AuthenticationStatus.Get(0, "Invalid password");
            }

            var singInResult = await _singInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (singInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                return AuthenticationStatus.Get(1, "Logged is successfully");
            }
            else if (singInResult.IsLockedOut)
            {
                return AuthenticationStatus.Get(0, "User locked out");
            }
            else
            {
                return AuthenticationStatus.Get(0, "Error on loggin in");
            }
        }

        public async Task LogoutAsync()
        {
            await _singInManager.SignOutAsync();
        }
    }
}