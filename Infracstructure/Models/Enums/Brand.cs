﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models.Enums
{
    public class Brand
    {
        [Key]
        public string BrandId { get; set; } = Guid.NewGuid().ToString();
        public string BrandName { get; set; }
        public string? Logo { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Status { get; set; } 
    }
}
