using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TicketR.MessageBroker.Integrations.Interfaces;
using TicketR.MessageBroker.Messages.Interfaces;
using TicketR.MessageBroker.Messages.Models;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;

namespace TicketR.MessageBroker.RabbitMQ.Messages
{
    public class RabbitMQMessageBroker : IMessageBroker, IDisposable
    {
        private readonly IRabbitMQConnection _rabbitMqConnection;

        public RabbitMQMessageBroker(IRabbitMQConnection rabbitMqConnection)
        {
            _rabbitMqConnection = rabbitMqConnection;
        }

        public void Publish(Message message)
        {
            if (!_rabbitMqConnection.IsConnected)
            {
                _rabbitMqConnection.TryConnect();
            }

            using (var channel = _rabbitMqConnection.CreateModel())
            {
                var messageName = message.GetType().Name;
                var messageContent = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(messageContent);
                var properties = channel.CreateBasicProperties();

                channel.BasicPublish(exchange: "QueueName",
                    routingKey: messageName,
                    mandatory: true,
                    basicProperties: properties,
                    body: body);
            }
        }

        public void Subscribe<TMessage, TMessageIntegrationHandler>() 
            where TMessage : Message 
            where TMessageIntegrationHandler : IIntegrationMessageHandler<TMessage>
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe<TMessage, TMessageIntegrationHandler>() 
            where TMessage : Message 
            where TMessageIntegrationHandler : IIntegrationMessageHandler<TMessage>
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _rabbitMqConnection?.Dispose();
        }
    }
}
