using Notification.Infrastructure.Dtos;
using Notification.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEmailService
    {
        Task<ResponseMail<EmailResponse>> SendEmailAsync(MailRequestDto mailRequestDto);
    }
}
