using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetAllTriangle : IRequest<ICollection<Triangle>>;
}
