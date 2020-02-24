using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Services.SendgridEmailInAspNetCore.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HopePipeline.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailAuthOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EmailAuthOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(List<string> emails, string subject, string message)
        {

            return Execute(Environment.GetEnvironmentVariable("SENDEMAILDEMO_ENVIRONMENT_SENDGRID_KEY"), subject, message, emails);
        }

        public Task Execute(string apiKey, string subject, string message, List<string> emails)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@domain.com", "Bekenty Jean Baptiste"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            Task response = client.SendEmailAsync(msg);
            return response;
        }
    }
}
