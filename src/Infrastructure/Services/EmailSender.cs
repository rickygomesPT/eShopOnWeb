using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Net;

namespace Microsoft.eShopWeb.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private ISendGridClient _sendGridClient;
        private IConfiguration _configuration;

        public EmailSender(
            ISendGridClient sendGridClient,
            IConfiguration configuration)
        {
            _sendGridClient = sendGridClient;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {

            var from = _configuration.GetValue<string>("SendGrid:from");
            var fromName = _configuration.GetValue<string>("SendGrid:fromName");

            if (string.IsNullOrEmpty(from))
            {
                throw new Exception("Email From is null or empty");
            }

            var From = new EmailAddress(from);
            var To = new EmailAddress(email);
            string plainTextContent = string.Empty;
            var msg = MailHelper.CreateSingleEmail(From, To, subject, plainTextContent, message);
            var response = await _sendGridClient.SendEmailAsync(msg);

        }
    }
}