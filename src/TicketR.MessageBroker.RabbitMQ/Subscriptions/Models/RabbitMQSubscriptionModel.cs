using System;
using System.Collections.Generic;
using System.Text;

namespace TicketR.MessageBroker.RabbitMQ.Subscriptions.Models
{
    public class RabbitMQSubscriptionModel
    {
        public Type HandlerType { get; set; }
    }
}
