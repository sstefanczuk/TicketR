using System;
using RabbitMQ.Client;

namespace TicketR.MessageBroker.RabbitMQ.Infrastructure.Connections.Interfaces
{
    public interface IRabbitMQConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
