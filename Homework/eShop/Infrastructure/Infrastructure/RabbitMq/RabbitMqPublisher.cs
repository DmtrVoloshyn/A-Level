using System.Text;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.Services.Interfaces;
using RabbitMQ.Client;

namespace Infrastructure.RabbitMq;

public class RabbitMqPublisher<TIntegrationEvent> : IEventPublisher<TIntegrationEvent>, IDisposable
    where TIntegrationEvent : IntegrationEvent
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IJsonSerializer _jsonSerializer;

    public RabbitMqPublisher(string queueName, 
        string exchangeName,
        ConnectionFactory connectionFactory, 
        IJsonSerializer jsonSerializer)
    {
        _jsonSerializer = jsonSerializer;
        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.ExchangeDeclare(exchange: exchangeName,
            durable: false,
            autoDelete: false,
            arguments: null,
            type: "direct"
        );
         
        _channel.QueueDeclare(queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
     
    public Task PublishAsync(TIntegrationEvent @event)
    {
        var jsonMessage = _jsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(jsonMessage);
         
        _channel.BasicPublish(exchange: string.Empty,
            routingKey: "hello",
            basicProperties: null,
            body: body);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _connection.Dispose();
        _channel.Dispose();
    }
}
