using AmazonSES_API.Models;

namespace AmazonSES_API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
