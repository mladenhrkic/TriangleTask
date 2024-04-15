using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetTriangleByUserId : IRequest<ICollection<Triangle>>
    {
        public string UserId { get; set; }
    }
}
