using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetImageByIdHandler(IImageTableRepository imageTable) :
        IRequestHandler<GetImageById, ImageTable>
    {
        public async Task<ImageTable> Handle(GetImageById request, CancellationToken cancellationToken)
        {
            return await imageTable.GetImageById(request.ImageId);
        }
    }
}