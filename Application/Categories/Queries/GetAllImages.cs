using Domain.Models;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetAllImages : IRequest<ICollection<ImageTable>>;
}