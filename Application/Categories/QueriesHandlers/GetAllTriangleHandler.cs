using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetAllTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<GetAllTriangle, ICollection<Triangle>>
    {
        private readonly ITriangleRepository _repository = repository;

        public async Task<ICollection<Triangle>> Handle(GetAllTriangle request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllTriangle();
        }
    }
}