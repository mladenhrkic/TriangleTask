using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Categories.QueriesHandlers
{
    public class GetAllImagesHandler(IImageTableRepository imageTableRepository) : 
        IRequestHandler<GetAllImages, ICollection<ImageTable>>
    {
        public async Task<ICollection<ImageTable>> Handle(GetAllImages request, CancellationToken cancellationToken)
        {
            return await imageTableRepository.GetAllImage();
        }
    }
}
