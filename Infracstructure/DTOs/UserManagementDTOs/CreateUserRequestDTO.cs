using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.UserManagementDTOs
{
    public class CreateUserRequestDTO
    {

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required, MinLength(6), MaxLength(100)]
        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(100)]
        public string ConfirmPassword {  get; set; }
        [Required]
        public bool? IsAgreement { get; set; }
     


    }
}
    