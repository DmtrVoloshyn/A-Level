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
    private readonly string _routingKey;
    private readonly string _exchangeName;
    private readonly string _queueName;

    public RabbitMqPublisher(
        string queueName, 
        string exchangeName,
        string routingKey,
        ConnectionFactory connectionFactory, 
        IJsonSerializer jsonSerializer)
    {
        _queueName = queueName;
        _exchangeName = exchangeName;
        _routingKey = routingKey;
        _jsonSerializer = jsonSerializer;
        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.ExchangeDeclare(exchange: _exchangeName,
            type: "direct"
        );
         
        _channel.QueueDeclare(queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
     
    public Task PublishAsync(TIntegrationEvent @event)
    {
        var jsonMessage = _jsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(jsonMessage);
         
        _channel.BasicPublish(
            exchange: _exchangeName,
            routingKey: _routingKey,
            basicProperties: null,
            body: body
            );

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _connection.Dispose();
        _channel.Dispose();
    }
}
