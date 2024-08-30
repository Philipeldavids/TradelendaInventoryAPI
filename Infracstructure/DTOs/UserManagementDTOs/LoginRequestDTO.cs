using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.UserManagementDTOs
{
    public class LoginRequestDTO
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(100)]
        public string Password { get; set; }
    }
}
