using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.UserManagement
{
    public class Role
    {
        public Guid RoleId { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; }

        public List<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
