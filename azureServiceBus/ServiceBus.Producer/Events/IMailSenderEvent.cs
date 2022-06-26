using ServiceBus.Producer.Models;

namespace ServiceBus.Producer.Events
{
    public interface IMailSenderEvent
    {
        bool SendMail(Email email);
    }
}