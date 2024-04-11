using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetImageById : IRequest<ImageTable>
    {
        public int ImageId { get; set; }
    }
}