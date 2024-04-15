using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetTriangleById : IRequest<Triangle>
    {
        public int TriangleId { get; set; }
    }
}
