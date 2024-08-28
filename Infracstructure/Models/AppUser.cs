using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserName { get; set; }
     
        public DateTime CreatedOn { get; set; }
        public bool Status {  get; set; }
        public Roles Userrole { get; set; }

    }
}
