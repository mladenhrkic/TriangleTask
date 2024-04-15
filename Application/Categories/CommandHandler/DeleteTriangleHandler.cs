using Application.Categories.Commands;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.CommandHandler
{
    public class DeleteTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<DeleteTriangle>
    {
        public async Task Handle(DeleteTriangle request, CancellationToken cancellationToken)
        {
            await repository.DeleteTriangle(request.TriangleId);
        }
    }
}