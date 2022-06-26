using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using ServiceBus.Consumer.Manager.Interface;
using ServiceBus.Consumer.Setting;

namespace ServiceBus.Consumer.MessageBroker
{
    public static class MailQueueConsume
    {
        public static void Consume(IServiceProvider serviceProvider)
        {
            var consumer = serviceProvider.GetService<ISendMailManager>();
        }
    }
}