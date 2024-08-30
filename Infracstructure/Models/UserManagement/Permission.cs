using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.UserManagement
{
    public class Permission
    {
        public Guid PermissionId { get; set; }

        [Required, MaxLength(100)]
        public string PermissionName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }


    public enum Permissions
    {
        ViewUsers,
        EditUsers,
        DeleteUsers,
        CreateUsers               
    }
}
