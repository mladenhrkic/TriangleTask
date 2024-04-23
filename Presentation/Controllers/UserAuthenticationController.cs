using Application.Categories.Authentication;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public UserAuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new LoginAuthentication
            {
                LoginModel = model
            });

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }

            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutAuthentication());
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Registration()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var registration = new RegistrationAuthentication
            {
                RegistrationModel = model
            };
            registration.RegistrationModel.Role = "user";

            var result = await _mediator.Send(registration);

            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }
    }
}