using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetAllTriangleHandler(ITriangleRepository repository) :
        IRequestHandler<GetAllTriangle, ICollection<Triangle>>
    {
        public async Task<ICollection<Triangle>> Handle(GetAllTriangle request, CancellationToken cancellationToken)
        {
            return await repository.GetAllTriangle();
        }
    }
}