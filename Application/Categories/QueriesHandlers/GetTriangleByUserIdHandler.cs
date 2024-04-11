using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetTriangleByUserIdHandler(ITriangleRepository repository) :
        IRequestHandler<GetTriangleByUserId, ICollection<Triangle>>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task<ICollection<Triangle>> Handle(GetTriangleByUserId request, CancellationToken cancellationToken)
        {
            return await _repository.GetTriangleByUserId(request.UserId);
        }
    }
}