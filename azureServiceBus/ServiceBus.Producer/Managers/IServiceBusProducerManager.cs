using System.Threading.Tasks;

namespace ServiceBus.Producer.Managers
{
    public interface IServiceBusProducerManager
    {
        Task<bool> SendQueue(string queueName, string connectionString, object data);
    }
}