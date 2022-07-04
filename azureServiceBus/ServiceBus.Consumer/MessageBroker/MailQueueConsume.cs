using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServiceBus.Consumer.Manager.Interface;
using ServiceBus.Consumer.Models;

namespace ServiceBus.Consumer.MessageBroker
{
    public static class MailQueueConsume
    {
        public async static void Consume(IServiceProvider serviceProvider)
        {
            string connectionString =
                "Endpoint=sb://thorin.servicebus.windows.net/;SharedAccessKeyName=mailPolicy;SharedAccessKey=B/LHAvAJIEyB/ukIuZccPzAA+xz3UY8mnOiZabsQUD8=;EntityPath=email-queue";
            string queueName = "email-queue";
            ServiceBusClient client = new ServiceBusClient(connectionString);
            ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
            try
            {
                var _sendMailManager = serviceProvider.GetService<ISendMailManager>();

                processor.ProcessMessageAsync += (ProcessMessageEventArgs args) =>
                {
                    string body = args.Message.Body.ToString();
                    Console.WriteLine($"Received: {body}");
                    var mailData = JsonConvert.DeserializeObject<Email>(body);
                    _sendMailManager.SendMail(mailData);
                    args.CompleteMessageAsync(args.Message).GetAwaiter().GetResult();
                    return Task.CompletedTask;
                };

                processor.ProcessErrorAsync += ErrorHandler;
                
                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
        }
        
        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }


    }
}