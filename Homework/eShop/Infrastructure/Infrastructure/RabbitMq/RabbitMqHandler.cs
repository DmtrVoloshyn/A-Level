using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Infrastructure.RabbitMq
{
    public class RabbitMqHandler<TIntegrationEvent>
        : IDisposable, IEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly EventingBasicConsumer _consumer;
        private readonly TaskCompletionSource<string> _tcs;
        private readonly ILogger<RabbitMqHandler<TIntegrationEvent>> _logger;

        public RabbitMqHandler(string queueName,
            string exchangeName,
            ConnectionFactory connectionFactory,
            IJsonSerializer jsonSerializer,
            ICustomRabbitHandler<TIntegrationEvent> requiredService,
            ILogger<RabbitMqHandler<TIntegrationEvent>> logger)
        {
            _logger = logger;
            _jsonSerializer = jsonSerializer;
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            _channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: queueName);


            _consumer = new EventingBasicConsumer(_channel);
            _tcs = new TaskCompletionSource<string>();

            _consumer.Received += async(model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Received message: {message}");

                    var integrationEvent = _jsonSerializer.Deserialize<TIntegrationEvent>(message);
                    await requiredService.HandleAsync(integrationEvent);
                    _tcs.SetResult(message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error processing message");
                    _tcs.SetResult($"Error: {e.Message}");
                }
            };

            _channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: _consumer);
        }

        //TEST METHOD
        public Task<string> Consume()
        {
            return _tcs.Task;
        }
        
        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
