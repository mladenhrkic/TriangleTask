using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries
{
    public class GetTriangleByUserId : IRequest<ICollection<Triangle>>
    {
        public string UserId { get; set; }
    }
}
