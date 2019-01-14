using System;
using System.Collections.Generic;
using System.Linq;
using TicketR.MessageBroker.RabbitMQ.Messages.Handlers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Messages.Models;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers.Interfaces;
using TicketR.MessageBroker.RabbitMQ.Subscriptions.Models;

namespace TicketR.MessageBroker.RabbitMQ.Subscriptions.Managers
{
    public class RabbitMQSubscriptionManager : IRabbitMQSubscriptionManager
    {
        private readonly Dictionary<string, List<RabbitMQSubscriptionModel>> _handlers;
        private readonly List<Type> _messageTypes;

        public RabbitMQSubscriptionManager()
        {
            _handlers = new Dictionary<string, List<RabbitMQSubscriptionModel>>();
            _messageTypes = new List<Type>();
        }

        public bool IsEmpty => !_handlers.Keys.Any();
        public event EventHandler<string> OnMessageRemoved;

        public void AddSubscription<T, TH>() where T : RabbitMQMessage where TH : IRabbitMQMessageHandler<T>
        {
            var messageName = GetMessageKey<T>();
            DoAddSubscription(typeof(TH), messageName);
            _messageTypes.Add(typeof(T));
        }

        public void RemoveSubscription<T, TH>() where T : RabbitMQMessage where TH : IRabbitMQMessageHandler<T>
        {
            var handlerToRemove = FindSubscriptionToRemove<T, TH>();
            var messageName = GetMessageKey<T>();
            DoRemoveHandler(messageName, handlerToRemove);
        }

        public bool HasSubscriptionsForMessage<T>() where T : RabbitMQMessage
        {
            var key = GetMessageKey<T>();
            return HasSubscriptionsForMessage(key);
        }

        public bool HasSubscriptionsForMessage(string eventName) => _handlers.ContainsKey(eventName);

        public Type GetEventTypeByName(string eventName) => _messageTypes.SingleOrDefault(t => t.Name == eventName);

        public void Clear() => _handlers.Clear();

        public IEnumerable<RabbitMQSubscriptionModel> GetHandlersForMessage<T>() where T : RabbitMQMessage
        {
            var key = GetMessageKey<T>();
            return GetHandlersForMessage(key);
        }

        public IEnumerable<RabbitMQSubscriptionModel> GetHandlersForMessage(string eventName) => _handlers[eventName];

        public string GetMessageKey<T>()
        {
            return typeof(T).Name;
        }

        private void DoAddSubscription(Type handlerType, string eventName)
        {
            if (!HasSubscriptionsForMessage(eventName))
            {
                _handlers.Add(eventName, new List<RabbitMQSubscriptionModel>());
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(new RabbitMQSubscriptionModel()
            {
                HandlerType = handlerType
            });
        }

        private RabbitMQSubscriptionModel FindSubscriptionToRemove<T, TH>()
            where T : RabbitMQMessage
            where TH : IRabbitMQMessageHandler<T>
        {
            var eventName = GetMessageKey<T>();
            return DoFindSubscriptionToRemove(eventName, typeof(TH));
        }

        private RabbitMQSubscriptionModel DoFindSubscriptionToRemove(string messageName, Type handlerType)
        {
            if (!HasSubscriptionsForMessage(messageName))
                return null;

            return _handlers[messageName].SingleOrDefault(s => s.HandlerType == handlerType);
        }

        private void DoRemoveHandler(string messageName, RabbitMQSubscriptionModel subsToRemove)
        {
            if (subsToRemove == null)
                return;

            _handlers[messageName].Remove(subsToRemove);

            if (_handlers[messageName].Any())
                return;

            _handlers.Remove(messageName);
            var eventType = _messageTypes.SingleOrDefault(e => e.Name == messageName);

            if (eventType != null)
            {
                _messageTypes.Remove(eventType);
            }

            RaiseOnMessageRemoved(messageName);
        }

        private void RaiseOnMessageRemoved(string messageName)
        {
            var handler = OnMessageRemoved;
            if (handler != null)
            {
                OnMessageRemoved?.Invoke(this, messageName);
            }
        }
    }
}
