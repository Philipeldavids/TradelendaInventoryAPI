using Microsoft.AspNet.Identity.EntityFramework;
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
        public string RoleId { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(50)]
        public string RoleName { get; set; }

        public List<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
