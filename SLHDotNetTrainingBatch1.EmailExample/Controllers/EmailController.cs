using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SLHDotNetTrainingBatch1.EmailExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //private IFluentEmail _fluentEmail;

        //public EmailController(IFluentEmail fluentEmail)
        //{
        //    _fluentEmail = fluentEmail;
        //}

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] EmailRequestModel requestModel)
        {
            //var response = await _fluentEmail
            //  .To(requestModel.ToEmail)
            //  .Subject(requestModel.Subject)
            //  .Body(requestModel.Body)
            //  .SendAsync();
            //return Ok(response);
            var model = await _emailService.SendAsync(requestModel.ToEmail, requestModel.Subject, requestModel.Body);
            return Ok(model);
        }
    }

    public class EmailRequestModel
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }

    public class EmailService : IEmailService
    {
        private IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task<SendResponse> SendAsync(string toEmail, string subject, string body)
        {
            var response = await _fluentEmail
                   .To(toEmail)
                   .Subject(subject)
                   .Body(body)
                   .SendAsync();
            return response;
        }
    }

    public interface IEmailService
    {
        Task<SendResponse> SendAsync(string toEmail, string subject, string body);
    }

    public class EmailV2Service : IEmailService
    {
        public Task<SendResponse> SendAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
