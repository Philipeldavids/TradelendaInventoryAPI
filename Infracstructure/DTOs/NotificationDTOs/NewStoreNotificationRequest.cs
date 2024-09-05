using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.DTOs.NotificationDTOs
{
    public class NewStoreNotificationRequest
    {
        public Store Store { get; set; }
        public string RecipientEmail { get; set; }
    }
}
