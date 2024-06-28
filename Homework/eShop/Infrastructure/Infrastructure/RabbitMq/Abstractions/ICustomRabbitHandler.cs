using Infrastructure.RabbitMq.Messages;

namespace Infrastructure.RabbitMq.Abstractions;

public interface ICustomRabbitHandler<TIntegrationMessage> 
    where TIntegrationMessage : IntegrationEvent
{
    Task HandleAsync(TIntegrationMessage @event);
}