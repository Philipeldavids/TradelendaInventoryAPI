using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.UserManagementDTOs
{
    public class SelectRoleDTO
    {
        public bool Customer { get; set; } = false;
        public bool ShopOwner { get; set; } = false;
    }

   
}
