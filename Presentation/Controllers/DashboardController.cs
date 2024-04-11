using Application.Categories.Commands;
using Application.Categories.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Display()
        {
            var getCommnd = new GetAllTriangle();
            var triangles = await _mediator.Send(getCommnd);
            return View(triangles);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Triangle triangle)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Triangle()
                {
                    
                };
                await _mediator.Send(newCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(triangle);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "edit";
            var edit = new GetTriangleById { TriangleId = id };
            var category = await _mediator.Send(edit);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Triangle triangle)
        {
            if (ModelState.IsValid)
            {
                var edit = new UpdateTriangle()
                {
                    //CategoryId = category.CategoryId,
                    //Name = category.Name,
                    //Description = category.Description
                };

                await _mediator.Send(edit);

                return RedirectToAction(nameof(Index));
            }
            return View(triangle);
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            await _mediator.Send(new DeleteTriangle() { TriangleId = categoryId });
            return RedirectToAction(nameof(Index));
        }
    }
}
