using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetTriangleByIdHandler(ITriangleRepository repository) :
        IRequestHandler<GetTriangleById, Triangle>
    {
        public async Task<Triangle> Handle(GetTriangleById request, CancellationToken cancellationToken)
        {
            return await repository.GetTriangleById(request.TriangleId);
        }
    }
}