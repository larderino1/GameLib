using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Services.EmailService
{
    public class EmailService : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sendGridKey = _config.GetValue<string>("SendGridKey");

            var client = new SendGridClient(sendGridKey);

            var message = new SendGridMessage
            {
                From = new EmailAddress(),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            message.AddTo(email);

            message.SetClickTracking(true, true);

            await client.SendEmailAsync(message);
        }
    }
}
