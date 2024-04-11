using Application.Categories.Commands;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.CommandHandler
{
    public class DeleteTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<DeleteTriangle>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task Handle(DeleteTriangle request, CancellationToken cancellationToken)
        {
            await _repository.DeleteTriangle(request.TriangleId);
        }
    }
}