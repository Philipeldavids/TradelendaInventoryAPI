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
        public string SupplierID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public int Code { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? ContactPerson { get; set; }
    }
}
