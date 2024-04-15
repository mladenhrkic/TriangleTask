using Domain.Models;
using MediatR;

namespace Application.Categories.Service
{
    public class TriangleCalculator : IRequest<Triangle>
    {
        public Triangle? Triangle { get; set; }
    }
}