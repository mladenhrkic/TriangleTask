﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries
{
    public class GetTriangleById : IRequest<Triangle>
    {
        public int TriangleId { get; set; }
    }
}
