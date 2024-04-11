using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Id { get; set; }
        public string Name { get; set; }
        //public string UserName { get; set; }
       //public string Email { get; set; }
       // public bool EmailConfirmed { get; set; }
        public string? ProfilePicture { get; set; }

        //public string SecurityStamp { get; set; }


        //public string PasswordHash { get; set; }
    }
}
