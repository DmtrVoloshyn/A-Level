using Infrastructure.RabbitMq;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.RabbitMq.Messages.BasketMessages;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using OrderProcessor.Configurations;
using RabbitMQ.Client;

namespace OrderProcessor.RabbitMq;

public class HostedService : BackgroundService
{
    private readonly List<IDisposable> _disposables;
    private readonly IServiceScope _scope;
    private readonly string _routingKey;
    private readonly RabbitConsumersConfiguration _config;

    public HostedService(IServiceProvider provider, IOptions<RabbitConsumersConfiguration> config, string routingKey)
    {
        _routingKey = routingKey;
        _config = config.Value;
        _scope = provider.CreateScope();
        _disposables = new List<IDisposable>();
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RegisterConsumer<OrderStartedIntegrationEvent>(
            _config.Consumers.QueueName, 
            _config.Consumers.ExchangeName);

        return Task.CompletedTask;
    }

    private void RegisterConsumer<TIntegrationMessage>(string queueName, string exchangeName) 
        where TIntegrationMessage 
        : IntegrationEvent
    {
        _disposables.Add(new RabbitMqHandler<TIntegrationMessage>(
            queueName, 
            exchangeName,
            _routingKey,
            _scope.ServiceProvider.GetRequiredService<ConnectionFactory>(),
            _scope.ServiceProvider.GetRequiredService<IJsonSerializer>(),
            _scope.ServiceProvider.GetRequiredService<ICustomRabbitHandler<TIntegrationMessage>>(),
            _scope.ServiceProvider.GetRequiredService<ILogger<RabbitMqHandler<TIntegrationMessage>>>()));
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        foreach (var i in _disposables)
        {
            i.Dispose();
        }
        
        _scope.Dispose();
        
        return base.StopAsync(cancellationToken);
    }
}