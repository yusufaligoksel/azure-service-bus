namespace ServiceBus.Producer.Managers
{
    public interface IServiceBusProducerManager
    {
        bool SendQueue(string queueName, string connectionString, object data);

    }
}