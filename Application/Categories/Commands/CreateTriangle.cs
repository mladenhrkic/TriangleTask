using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands
{
    public class CreateTriangle : IRequest
    {
        public Triangle Triangle { get; set; }
    }
}
