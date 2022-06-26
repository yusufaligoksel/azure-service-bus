using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace ServiceBus.Producer.Managers
{
    public class ServiceBusProducerManager : IServiceBusProducerManager
    {
        public async Task<bool> SendQueue(string queueName, string connectionString, object data)
        {
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            try
            {
                using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                messageBatch.TryAddMessage(new ServiceBusMessage(BinaryData.FromObjectAsJson(data)));

                await sender.SendMessagesAsync(messageBatch);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}