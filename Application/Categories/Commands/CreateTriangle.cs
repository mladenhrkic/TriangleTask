using Domain.Models;
using MediatR;

namespace Application.Categories.Commands
{
    public class CreateTriangle : IRequest
    {
        public Triangle Triangle { get; set; }
    }
}
