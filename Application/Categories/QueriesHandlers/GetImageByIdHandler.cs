using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetImageByIdHandler(IImageTableRepository imageTable) :
        IRequestHandler<GetImageById, ImageTable>
    {
        private readonly IImageTableRepository _imageTable = imageTable;

        public async Task<ImageTable> Handle(GetImageById request, CancellationToken cancellationToken)
        {
            return await _imageTable.GetImageById(request.ImageId);
        }
    }
}