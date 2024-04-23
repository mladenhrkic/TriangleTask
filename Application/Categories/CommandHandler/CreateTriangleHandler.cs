using Application.Categories.Commands;
using Domain.Abstractions;
using MediatR;

namespace Application.Categories.CommandHandler
{
    public class CreateTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<CreateTriangle>
    {
        public async Task Handle(CreateTriangle request, CancellationToken cancellationToken)
        {
            await repository.CreateTriangle(request.Triangle);
        }
    }
}