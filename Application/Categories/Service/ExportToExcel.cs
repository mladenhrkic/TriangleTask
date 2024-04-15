using Domain.Models;
using MediatR;

namespace Application.Categories.Service
{
    public class ExportToExcel : IRequest
    {
        public ICollection<Triangle> Triangles { get; set; }
    }
}
