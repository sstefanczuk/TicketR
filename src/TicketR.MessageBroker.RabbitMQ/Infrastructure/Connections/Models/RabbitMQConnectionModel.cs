namespace TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Models
{
    public class RabbitMQConnectionModel
    {
        public string RabbitHostName { get; set; }
        public string RabbitUserName { get; set; }
        public string RabbitPassword { get; set; }
        public string RabbitServiceQueue { get; set; }
    }
}
