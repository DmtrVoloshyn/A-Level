using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Infrastructure.RabbitMq
{
    public class RabbitMqHandler<TIntegrationEvent>
        : IDisposable, IEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly AsyncEventingBasicConsumer _consumer;
        private readonly TaskCompletionSource<string> _tcs;
        private readonly string _queueName;
        private readonly string _exchangeName;
        private readonly string _routingKey;

        public RabbitMqHandler(
            string queueName,
            string exchangeName,
            string routingKey,
            ConnectionFactory connectionFactory,
            IJsonSerializer jsonSerializer,
            ICustomRabbitHandler<TIntegrationEvent> requiredService,
            ILogger<RabbitMqHandler<TIntegrationEvent>> logger)
        {
            _queueName = queueName;
            _exchangeName = exchangeName;
            _routingKey = routingKey;
            ILogger<RabbitMqHandler<TIntegrationEvent>> logger1 = logger;
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.ExchangeDeclare(exchange: _exchangeName,
                type: "direct"
                );

            _channel.QueueDeclare(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
            _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: _routingKey);


            _consumer = new AsyncEventingBasicConsumer(_channel);
            _tcs = new TaskCompletionSource<string>();

            _consumer.Received += async(model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    logger1.LogInformation($"Received message: {message}");

                    var integrationEvent = jsonSerializer.Deserialize<TIntegrationEvent>(message);
                    await requiredService.HandleAsync(integrationEvent);
                    _tcs.SetResult(message);
                }
                catch (Exception e)
                {
                    logger1.LogError(e, "Error processing message");
                    _tcs.SetResult($"Error: {e.Message}");
                }
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: true,
                consumer: _consumer
                );
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
