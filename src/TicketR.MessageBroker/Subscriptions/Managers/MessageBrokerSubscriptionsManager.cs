using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketR.MessageBroker.Integrations.Interfaces;
using TicketR.MessageBroker.Messages.Models;
using TicketR.MessageBroker.Subscriptions.Managers.Interfaces;
using TicketR.MessageBroker.Subscriptions.Models;

namespace TicketR.MessageBroker.Subscriptions
{
    public class MessageBrokerSubscriptionsManager : IMessageBrokerSubscriptionsManager
    {
        private readonly Dictionary<string, List<SubscriptionModel>> _handlers;
        private readonly List<Type> _messageTypes;

        public MessageBrokerSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<SubscriptionModel>>();
            _messageTypes = new List<Type>();
        }

        public bool IsEmpty => !_handlers.Keys.Any();
        public event EventHandler<string> OnMessageRemoved;

        public void AddSubscription<T, TH>() where T : Message where TH : IIntegrationMessageHandler<T>
        {
            var messageName = GetMessageKey<T>();
            DoAddSubscription(typeof(TH), messageName);
            _messageTypes.Add(typeof(T));
        }

        public void RemoveSubscription<T, TH>() where T : Message where TH : IIntegrationMessageHandler<T>
        {
            var handlerToRemove = FindSubscriptionToRemove<T, TH>();
            var messageName = GetMessageKey<T>();
            DoRemoveHandler(messageName, handlerToRemove);
        }

        public bool HasSubscriptionsForEvent<T>() where T : Message
        {
            var key = GetMessageKey<T>();
            return HasSubscriptionsForEvent(key);
        }

        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

        public Type GetEventTypeByName(string eventName) => _messageTypes.SingleOrDefault(t => t.Name == eventName);

        public void Clear() => _handlers.Clear();

        public IEnumerable<SubscriptionModel> GetHandlersForEvent<T>() where T : Message
        {
            var key = GetMessageKey<T>();
            return GetHandlersForEvent(key);
        }

        public IEnumerable<SubscriptionModel> GetHandlersForEvent(string eventName) => _handlers[eventName];

        public string GetMessageKey<T>()
        {
            return typeof(T).Name;
        }

        private void DoAddSubscription(Type handlerType, string eventName)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionModel>());
            }

            if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(new SubscriptionModel()
            {
                HandlerType = handlerType
            });
        }

        private SubscriptionModel FindSubscriptionToRemove<T, TH>()
            where T : Message
            where TH : IIntegrationMessageHandler<T>
        {
            var eventName = GetMessageKey<T>();
            return DoFindSubscriptionToRemove(eventName, typeof(TH));
        }

        private SubscriptionModel DoFindSubscriptionToRemove(string messageName, Type handlerType)
        {
            if (!HasSubscriptionsForEvent(messageName))
                return null;

            return _handlers[messageName].SingleOrDefault(s => s.HandlerType == handlerType);
        }

        private void DoRemoveHandler(string messageName, SubscriptionModel subsToRemove)
        {
            if (subsToRemove != null)
            {
                _handlers[messageName].Remove(subsToRemove);
                if (!_handlers[messageName].Any())
                {
                    _handlers.Remove(messageName);
                    var eventType = _messageTypes.SingleOrDefault(e => e.Name == messageName);
                    if (eventType != null)
                    {
                        _messageTypes.Remove(eventType);
                    }
                    RaiseOnMessageRemoved(messageName);
                }

            }
        }

        private void RaiseOnMessageRemoved(string messageName)
        {
            var handler = OnMessageRemoved;
            if (handler != null)
            {
                OnMessageRemoved(this, messageName);
            }
        }
    }
}
