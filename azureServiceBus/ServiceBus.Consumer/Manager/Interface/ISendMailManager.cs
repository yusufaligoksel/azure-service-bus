using ServiceBus.Consumer.Models;

namespace ServiceBus.Consumer.Manager.Interface
{
    public interface ISendMailManager
    {
        bool SendMail(Email email);
    }
}