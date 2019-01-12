using System;
using System.Collections.Generic;
using System.Text;
using TicketR.MessageBroker.Infrastructure.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;

namespace TicketR.MessageBroker.RabbitMQ.Messages.Interfaces
{
    public interface IRabbitMQMessageHandler<in TMessage> : IMessageHandler<TMessage> where TMessage : RabbitMQMessage
    {
    }
}
