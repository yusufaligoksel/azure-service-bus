namespace ServiceBus.Consumer.Models
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}