using MediatR;

namespace Application.Categories.Commands
{
    public class DeleteTriangle : IRequest
    {
        public int TriangleId { get; set; }
    }
}
