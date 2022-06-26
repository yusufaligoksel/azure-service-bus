using ServiceBus.Consumer.Manager.Interface;
using ServiceBus.Consumer.Models;

namespace ServiceBus.Consumer.Manager
{
    public class SendMailManager:ISendMailManager
    {
        public bool SendMail(Email email)
        {
            //todo bi ara free third party mail entegrasyonu yaparım
            return true;
        }
    }
}