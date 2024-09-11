using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs
{
    public class CreateWarehouseDTO
    {
        public string WarehouseName { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNumber { get; set; }

        public string WorkPhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}
