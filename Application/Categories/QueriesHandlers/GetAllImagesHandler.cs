using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.QueriesHandlers
{
    public class GetAllImagesHandler(IImageTableRepository imageTableRepository) : 
        IRequestHandler<GetAllImages, ICollection<ImageTable>>
    {
        private readonly IImageTableRepository _imageTableRepository = imageTableRepository;

        public async Task<ICollection<ImageTable>> Handle(GetAllImages request, CancellationToken cancellationToken)
        {
            return await _imageTableRepository.GetAllImage();
        }
    }
}
