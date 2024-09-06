using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.UserManagementDTOs
{
    public class RegisterStoreUserRequestDTO
    {
        public CreateUserRequestDTO CreateUserRequest { get; set; }
        public SelectRoleDTO SelectRole { get; set; }
    }
}
