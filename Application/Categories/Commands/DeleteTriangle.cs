using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands
{
    public class DeleteTriangle : IRequest
    {
        public int TriangleId { get; set; }
    }
}
