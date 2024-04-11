using Application.Categories.Commands;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.CommandHandler
{
    internal class CreateTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<CreateTriangle>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task Handle(CreateTriangle request, CancellationToken cancellationToken)
        {
            await _repository.CreateTriangle(request.Triangle);
        }
    }
}