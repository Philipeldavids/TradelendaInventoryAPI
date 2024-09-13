using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.UserManagementDTOs
{
    public class UpdateUserRequestDTO
    {
        [MaxLength(50)]
        public string Username { get; set; }

        [EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [MinLength(6), MaxLength(100)]       

        public List<Guid> RoleIds { get; set; }

        public bool? IsActive { get; set; }
    }
}
