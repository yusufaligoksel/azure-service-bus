using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ServiceBus.Producer.Managers;
using ServiceBus.Producer.Models;
using ServiceBus.Producer.Setting;

namespace ServiceBus.Producer.Events
{
    public class MailSenderEvent:IMailSenderEvent
    {
        private readonly IServiceBusProducerManager _serviceBusProducerManager;
        private readonly ServiceBusSetting _serviceBusSetting;
        public MailSenderEvent(IServiceBusProducerManager serviceBusProducerManager,
            IOptions<ServiceBusSetting> _options)
        {
            _serviceBusProducerManager = serviceBusProducerManager;
            _serviceBusSetting = _options.Value;
        }
        public async Task<bool> SendMail(Email email)
        {
            var result = await _serviceBusProducerManager.SendQueue(_serviceBusSetting.MailQueue.QueueName,
                _serviceBusSetting.MailQueue.PrimaryConnectionString, email);

            return result;
        }
    }
}