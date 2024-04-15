using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetTriangleByUserIdHandler(ITriangleRepository repository) :
        IRequestHandler<GetTriangleByUserId, ICollection<Triangle>>
    {
        public async Task<ICollection<Triangle>> Handle(GetTriangleByUserId request, CancellationToken cancellationToken)
        {
            return await repository.GetTriangleByUserId(request.UserId);
        }
    }
}