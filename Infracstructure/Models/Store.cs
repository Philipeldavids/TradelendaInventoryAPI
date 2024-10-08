﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Models
{
    public class Store
    {
        [Key]
        public string StoreId { get; set; } = Guid.NewGuid().ToString();

 
        [Required]
        public string StoreName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;
        
        public string Email {  get; set; }

        public string PhoneNumber {  get; set; }
        public bool Status { get; set; }
    }

}
