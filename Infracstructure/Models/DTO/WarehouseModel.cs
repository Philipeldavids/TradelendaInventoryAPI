using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.DTO
{
    public class WarehouseModel
    {
        public string WarehouseID { get; set; } = Guid.NewGuid().ToString();
        public string WarehouseName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string WorkPhone { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;
    }
}
