using Domain.Abstractions;
using Domain.Models;
using Infrastructure.HelpFunctions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRegistrationService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Status> RegistrationAsync(RegistrationModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return AuthenticationStatus.Get(0, "User alredy exists");
            }

            var user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errorMessage = string.Join("\n", result.Errors.Select(error => error.Description));
                return AuthenticationStatus.Get(0, $"User creation failed. {errorMessage}");
            }

            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            return AuthenticationStatus.Get(1, "User has registered successfully");

        }
    }
}