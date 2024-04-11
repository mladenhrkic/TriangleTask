using Application.Categories.Service;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.ServiceHandler
{
    public class TriangleCalculatorHandler(ITriangleCalculator triangleCalculator) :
        IRequestHandler<TriangleCalculator, Triangle>
    {
        private readonly ITriangleCalculator _triangleCalculator = triangleCalculator;

        public async Task<Triangle> Handle(TriangleCalculator request, CancellationToken cancellationToken)
        {
            return await _triangleCalculator.Result(request.Triangle);
        }
    }
}