using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Authentication
{
    public class LoginAuthentication : IRequest<Status>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
