using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Store
    {
        [Key]
        public string StoreId { get; set; } = Guid.NewGuid().ToString();

        public string StoreName { get; set; }

        public string UserName { get; set; }

        public long PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }
    }
}
