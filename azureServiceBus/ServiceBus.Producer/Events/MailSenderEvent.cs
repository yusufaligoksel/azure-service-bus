using ServiceBus.Producer.Managers;
using ServiceBus.Producer.Models;

namespace ServiceBus.Producer.Events
{
    public class MailSenderEvent:IMailSenderEvent
    {
        private readonly IServiceBusProducerManager _serviceBusProducerManager;
        public MailSenderEvent(IServiceBusProducerManager serviceBusProducerManager)
        {
            _serviceBusProducerManager = serviceBusProducerManager;
        }
        public bool SendMail(Email email)
        {
            throw new System.NotImplementedException();
        }
    }
}