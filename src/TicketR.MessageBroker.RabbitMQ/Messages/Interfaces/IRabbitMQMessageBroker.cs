using System;
using System.Collections.Generic;
using System.Text;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;

namespace TicketR.MessageBroker.RabbitMQ.Messages.Interfaces
{
    public interface IRabbitMQMessageBroker
    {
        void Publish(RabbitMQMessage message);

        void Subscribe<TMessage, TRabbitMQMessageHandler>()
            where TMessage : RabbitMQMessage
            where TRabbitMQMessageHandler : IRabbitMQMessageHandler<TMessage>;

        void UnSubscribe<TRabbitMQMessage, TRabbitMQMessageHandler>()
            where TRabbitMQMessage : RabbitMQMessage
            where TRabbitMQMessageHandler : IRabbitMQMessageHandler<TRabbitMQMessage>;
    }
}
