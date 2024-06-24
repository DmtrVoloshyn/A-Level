using Infrastructure.RabbitMq.Messages;

namespace Infrastructure.RabbitMq.Abstractions
{
    public interface IEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {
        Task<string> Consume();
    }
}