using Infrastructure.RabbitMq;
using Infrastructure.RabbitMq.Abstractions;
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
    private readonly RabbitConsumersConfiguration _config;
    private readonly RabbitMqHandler<OrderStartedIntegrationEvent> _orderStartedIntegrationHandler;

    public HostedService(IServiceProvider provider, IOptions<RabbitConsumersConfiguration> config)
    {
        _config = config.Value;
        _scope = provider.CreateScope();
        _disposables = new List<IDisposable>();
        
        _orderStartedIntegrationHandler = new RabbitMqHandler<OrderStartedIntegrationEvent>(
            _config.Consumers.QueueName, 
            _config.Consumers.ExchangeName,
            _config.RoutingKey,
            _scope.ServiceProvider.GetRequiredService<ConnectionFactory>(),
            _scope.ServiceProvider.GetRequiredService<IJsonSerializer>(),
            _scope.ServiceProvider.GetRequiredService<ICustomRabbitHandler<OrderStartedIntegrationEvent>>(),
            _scope.ServiceProvider.GetRequiredService<ILogger<RabbitMqHandler<OrderStartedIntegrationEvent>>>());
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RegisterConsumer();

        return Task.CompletedTask;
    }

    private void RegisterConsumer()
    {
        _disposables.Add(_orderStartedIntegrationHandler);
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