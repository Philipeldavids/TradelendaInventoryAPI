using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.DTO
{
    public class BrandDTO
    {
        [Required, MaxLength(50)]
        public string BrandName { get; set; }
        
        public string? Logo { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}
