using Microsoft.AspNetCore.Mvc;
using ServiceBus.Producer.Events;
using ServiceBus.Producer.Models;

namespace ServiceBus.Producer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmailController : ControllerBase
    {
        private readonly IMailSenderEvent _mailSenderEvent;
        public EmailController(IMailSenderEvent mailSenderEvent)
        {
            _mailSenderEvent = mailSenderEvent;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] Email email)
        {
            var result = _mailSenderEvent.SendMail(email);
            return Ok(result);
        }
    }
}