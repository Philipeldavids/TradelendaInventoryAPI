using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.DTO
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }
       
        public string CategorySLug { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Status { get; set; }

    }
}
