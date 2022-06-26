namespace ServiceBus.Producer.Setting
{
    public class ServiceBusSetting
    {
        public MailQueue MailQueue { get; set; }
    }

    public class MailQueue
    {
        public string QueueName { get; set; }
        public string PrimaryConnectionString { get; set; }
        public string SecondaryConnectionString { get; set; }
    }
}