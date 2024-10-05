using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class StoreModel
    {
        [Required]
        public string StoreName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        public int WarehouseID { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
