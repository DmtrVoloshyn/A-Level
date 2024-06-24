using Infrastructure.RabbitMq.Messages;

namespace Infrastructure.RabbitMq.Abstractions;

public interface IEventPublisher<in TIntegrationEvent> 
    where TIntegrationEvent : IntegrationEvent
{
    Task PublishAsync(TIntegrationEvent @event);
}
