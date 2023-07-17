using AmazonSES_API.Models;
using AmazonSES_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonSES_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public EmailController(IMailService mailService)
        {
            this._mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendMail(MailRequest request)
        {
            await _mailService.SendEmailAsync(request);
            return Ok("Email Sent Successfully !");
        }
    }
}
