using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Consts;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces;

namespace TicketR.MessageBroker.RabbitMQ.Messages
{
    public class RabbitMQMessageBroker : IRabbitMQMessageBroker, IDisposable
    {
        private readonly IRabbitMQConnection _rabbitMqConnection;
        private readonly IRabbitMQSubscriptionManager _subscriptionManager;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private string _queueName;

        private IModel _consumerChannel;

        public RabbitMQMessageBroker(IRabbitMQConnection rabbitMqConnection, IRabbitMQSubscriptionManager subscriptionManager, IServiceScopeFactory serviceScopeFactory, string queueName)
        {
            _rabbitMqConnection = rabbitMqConnection;
            _subscriptionManager = subscriptionManager;           
            _serviceScopeFactory = serviceScopeFactory;
            _queueName = queueName;
            _consumerChannel = CreateConsumerChannel();
            _subscriptionManager.OnMessageRemoved += SubsManagerOnMessageRemoved;
        }

        public void Publish(RabbitMQMessage message)
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

                channel.BasicPublish(exchange: "TicketR_MessageBroker",
                    routingKey: messageName,
                    mandatory: true,
                    basicProperties: properties,
                    body: body);
            }
        }

        public void Subscribe<TRabbitMQMessage, TRabbitMQMessageHandler>() 
            where TRabbitMQMessage : RabbitMQMessage
            where TRabbitMQMessageHandler : IRabbitMQMessageHandler<TRabbitMQMessage>
        {
            var messageName = _subscriptionManager.GetMessageKey<TRabbitMQMessage>();
            DoInternalSubscription(messageName);
            _subscriptionManager.AddSubscription<TRabbitMQMessage, TRabbitMQMessageHandler>();
        }

        public void UnSubscribe<TRabbitMQMessage, TMessageIntegrationHandler>() 
            where TRabbitMQMessage : RabbitMQMessage
            where TMessageIntegrationHandler : IRabbitMQMessageHandler<TRabbitMQMessage>
        {
            _subscriptionManager.RemoveSubscription<TRabbitMQMessage, TMessageIntegrationHandler>();
        }

        private IModel CreateConsumerChannel()
        {
            if (!_rabbitMqConnection.IsConnected)
            {
                _rabbitMqConnection.TryConnect();
            }

            var channel = _rabbitMqConnection.CreateModel();

            channel.ExchangeDeclare(exchange: MessageConsts.BrokerName,
                type: "direct");

            channel.QueueDeclare(queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var eventName = ea.RoutingKey;
                var message = Encoding.UTF8.GetString(ea.Body);

                await ProcessEvent(eventName, message);

                channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queue: _queueName,
                autoAck: false,
                consumer: consumer);

            channel.CallbackException += (sender, ea) =>
            {
                _consumerChannel.Dispose();
                _consumerChannel = CreateConsumerChannel();
            };

            return channel;
        }

        public void Dispose()
        {
            _consumerChannel?.Dispose();
            _subscriptionManager.Clear();
        }

        private void SubsManagerOnMessageRemoved(object sender, string eventName)
        {
            if (!_rabbitMqConnection.IsConnected)
            {
                _rabbitMqConnection.TryConnect();
            }

            using (var channel = _rabbitMqConnection.CreateModel())
            {
                channel.QueueUnbind(queue: _queueName,
                    exchange: MessageConsts.BrokerName,
                    routingKey: eventName);

                if (_subscriptionManager.IsEmpty)
                {
                    _queueName = string.Empty;
                    _consumerChannel.Close();
                }
            }
        }

        private void DoInternalSubscription(string messageName)
        {
            var containsKey = _subscriptionManager.HasSubscriptionsForMessage(messageName);
            if (!containsKey)
            {
                if (!_rabbitMqConnection.IsConnected)
                {
                    _rabbitMqConnection.TryConnect();
                }

                using (var channel = _rabbitMqConnection.CreateModel())
                {
                    channel.QueueBind(queue: _queueName,
                        exchange: MessageConsts.BrokerName,
                        routingKey: messageName);
                }
            }
        }
        private async Task ProcessEvent(string messageName, string message)
        {
            if (_subscriptionManager.HasSubscriptionsForMessage(messageName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _subscriptionManager.GetHandlersForMessage(messageName);
                    foreach (var subscription in subscriptions)
                    {
                        var messageType = _subscriptionManager.GetEventTypeByName(messageName);
                        var integrationEvent = JsonConvert.DeserializeObject(message, messageType);
                        var handler = scope.ServiceProvider.GetService(subscription.HandlerType);
                        var concreteType = typeof(IRabbitMQMessageHandler<>).MakeGenericType(messageType);
                        await (Task)concreteType.GetMethod("Handle")?.Invoke(handler, new [] { integrationEvent });
                    }
                }
            }
        }
    }
}
