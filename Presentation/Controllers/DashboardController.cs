using Application.Categories.Commands;
using Application.Categories.Queries;
using Application.Categories.Service;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.HelpFunctions;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> Display()
        {
            if (User.IsInRole("admin"))
            {
                var triangles = await _mediator.Send(new GetAllTriangle());
                return View(triangles);
            }
            else
            {
                var triangles = await _mediator.Send(new GetTriangleByUserId()
                {
                    UserId = User.Identity.Name 
                });
                return View(triangles);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Action = "add";
            return View(Container.TriContainTriangleData);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Triangle triangle, IFormCollection form)
        {
            if (triangle.SideA == 0 || triangle.SideB == 0 || triangle.SideB == 0)
            {
                return RedirectToAction(nameof(Add));
            }
            if (form.Keys.Contains("calculate"))
            {
                Container.TriContainTriangleData = await _mediator.Send(new TriangleCalculator
                {
                    Triangle = triangle
                });
                return RedirectToAction("Add", "Dashboard");
            }

            var newCategory = new CreateTriangle
            {
                Triangle = triangle,
            };
            newCategory.Triangle.UserId = User.Identity.Name;

            await _mediator.Send(newCategory);
            return RedirectToAction(nameof(Display));
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "edit";
            if (Container.TriContainTriangleData != null)
            {
                return View(Container.TriContainTriangleData);
            }

            var category = await _mediator.Send(new GetTriangleById
            {
                TriangleId = id 
            });
            return View(category);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Triangle triangle, IFormCollection form)
        {
            if (triangle.SideA == 0 || triangle.SideB == 0 || triangle.SideB == 0)
            {
                return RedirectToAction(nameof(Edit));
            }
            if (form.Keys.Contains("calculate"))
            {
                var test = new TriangleCalculator
                {
                    Triangle = triangle
                };

                Container.TriContainTriangleData = await _mediator.Send(test);
                return RedirectToAction(nameof(Edit));
            }

            var edit = new UpdateTriangle();
            triangle.UserId = User.Identity.Name;
            edit.Triangle = triangle;

            await _mediator.Send(edit);

            return RedirectToAction(nameof(Display));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int categoryId)
        {
            await _mediator.Send(new DeleteTriangle() { TriangleId = categoryId });
            return RedirectToAction(nameof(Display));
        }

        [Authorize]
        public async Task<IActionResult> ExportToExcel(int id)
        {
            var getCommnd = new GetTriangleById { TriangleId = id };
            var collection = await _mediator.Send(getCommnd);

            collection.Image = "";
            collection.Image_2 = "";

            ICollection<Triangle> triangleCollection = [collection];

            var map = new ExportToExcel
            {
                Triangles = triangleCollection
            };
            if (map.Triangles.Count > 0)
            {
                await _mediator.Send(map);
            }

            return RedirectToAction(nameof(Display));
        }
    }
}
