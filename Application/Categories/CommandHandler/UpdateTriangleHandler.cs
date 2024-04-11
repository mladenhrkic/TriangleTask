using Application.Categories.Commands;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.CommandHandler
{
    public class UpdateTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<UpdateTriangle, Triangle>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task<Triangle> Handle(UpdateTriangle request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateTriangle(request.Triangle);
        }
    }
}