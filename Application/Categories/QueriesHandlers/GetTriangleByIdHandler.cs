using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetTriangleByIdHandler(ITriangleRepository repository) :
        IRequestHandler<GetTriangleById, Triangle>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task<Triangle> Handle(GetTriangleById request, CancellationToken cancellationToken)
        {
            return await _repository.GetTriangleById(request.TriangleId);
        }
    }
}