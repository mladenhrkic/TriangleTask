using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Service
{
    public class ExportToExcel : IRequest
    {
        public ICollection<Triangle> Triangles { get; set; }
    }
}
