//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infracstructure.Models.UserManagement
//{
//    public class User 
//    {
//        [Key]
//        [Required]

//        public string UserId { get; set; } = Guid.NewGuid().ToString();

//        [Required, MaxLength(50)]
//        public string UserName { get; set; }

//        [Required, EmailAddress, MaxLength(100)]
//        public string Email { get; set; }

//        [Required]
//        public string PasswordHash { get; set; }

//        public List<Role> Roles { get; set; } = new List<Role>();

//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        public DateTime? LastLogin { get; set; }

//        public bool IsActive { get; set; } = true;
//        public string RefreshToken { get; set; }
//        public DateTime RefreshTokenExpiryTime { get; set; }
//    }
//}


using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.UserManagement
{
    public class User
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public UserProfile UserProfile { get; set; }

        public Roles Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; } = true;

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
    public class UserProfile
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; }= string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;

    }
}

