using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using AmazonSES_API.Models;
using Microsoft.Extensions.Options;

namespace AmazonSES_API.Services
{
    public class SESSDKService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IAmazonSimpleEmailService _mailService;
        public SESSDKService(IOptions<MailSettings> mailSettings,
            IAmazonSimpleEmailService mailService)
        {
            _mailSettings = mailSettings.Value;
            _mailService = mailService;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var mailBody = new Body(new Content(mailRequest.Body));
            var message = new Message(new Content(mailRequest.Subject), mailBody);
            var destination = new Destination(new List<string> { mailRequest.ToEmail! });
            var request = new SendEmailRequest(_mailSettings.Mail, destination, message);
            await _mailService.SendEmailAsync(request);
        }
    }
}