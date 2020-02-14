using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopWeb.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private ISendGridClient _sendGridClient;
        private IConfiguration _configuration;

        private readonly ILogger<EmailSender> _logger;

        public EmailSender(
            ISendGridClient sendGridClient,
            IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _sendGridClient = sendGridClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {

            var from = _configuration.GetValue<string>("SendGrid:from");

            if (string.IsNullOrEmpty(from))
            {
                throw new Exception("Email From is null or empty");
            }

            var From = new EmailAddress(from);
            var To = new EmailAddress(email);
            string plainTextContent = string.Empty;
            var msg = MailHelper.CreateSingleEmail(From, To, subject, plainTextContent, message);
            var response = await _sendGridClient.SendEmailAsync(msg);
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                _logger.LogInformation($"Send e-mail.");
            }
            else
            {
                _logger.LogError($"Send e-mail not send");
            }

        }
    }
}