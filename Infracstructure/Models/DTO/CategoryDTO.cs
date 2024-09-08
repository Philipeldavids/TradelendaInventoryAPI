using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.DTO
{
    public class CategoryDTO
    {
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
       
        public string CategorySLug { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Status { get; set; }

    }
}
