using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Supplier
    {
        [Key]
        public string SupplierID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public int Code { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
