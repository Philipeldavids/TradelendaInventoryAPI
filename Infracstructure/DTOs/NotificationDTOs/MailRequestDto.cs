﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Dtos
{
    public class MailRequestDto
    {

        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }
       
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
