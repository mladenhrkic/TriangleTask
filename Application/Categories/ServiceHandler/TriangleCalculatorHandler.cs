using Application.Categories.Service;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.ServiceHandler
{
    public class TriangleCalculatorHandler(ITriangleCalculator triangleCalculator) :
        IRequestHandler<TriangleCalculator, Triangle>
    {
        public async Task<Triangle> Handle(TriangleCalculator request, CancellationToken cancellationToken)
        {
            return await triangleCalculator.Result(request.Triangle);
        }
    }
}