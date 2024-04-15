using Domain.Models;
using MediatR;

namespace Application.Categories.Commands
{
    public class UpdateTriangle : IRequest<Triangle>
    {
        public Triangle Triangle { get; set; }

    }
}
