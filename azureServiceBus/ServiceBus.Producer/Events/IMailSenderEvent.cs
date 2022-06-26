using System.Threading.Tasks;
using ServiceBus.Producer.Models;

namespace ServiceBus.Producer.Events
{
    public interface IMailSenderEvent
    {
        Task<bool> SendMail(Email email);
    }
}