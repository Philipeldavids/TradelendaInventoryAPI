using BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Notification.Infrastructure.Dtos;
using Notification.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResponseMail<EmailResponse>> SendEmailAsync(MailRequestDto mailRequestDto)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = _configuration["MailLoginDetails:HostName"]; 
                smtpClient.Port = Convert.ToInt16(_configuration["MailLoginDetails:PortNo"]); 
                smtpClient.Credentials = new NetworkCredential(_configuration["MailLoginDetails:HostMail"],
                                                          _configuration["MailLoginDetails:HostMailPass"]);
                smtpClient.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.To.Add(mailRequestDto.ToEmail);
                message.Subject = mailRequestDto.Subject;                
                message.From = new MailAddress(_configuration["MailLoginDetails:HostMail"]);
                message.Body = mailRequestDto.Message;
                smtpClient.Send(message);

                var result = new EmailResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Message = message.Body,
                    Subject = message.Subject,
                    ToEmail = mailRequestDto.ToEmail,
                    SentAt = DateTime.Now,
                    RequestedAt = DateTime.Now,
                };

                return new ResponseMail<EmailResponse>
                {
                    Data = result,
                    Message = "Successful",
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                //Log.Logger.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
