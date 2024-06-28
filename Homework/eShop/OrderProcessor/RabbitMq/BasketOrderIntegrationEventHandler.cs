using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages.BasketMessages;

namespace OrderProcessor.RabbitMq;

public class BasketOrderIntegrationEventHandler : ICustomRabbitHandler<OrderStartedIntegrationEvent>
{
    public Task HandleAsync(OrderStartedIntegrationEvent @event)
    {
        Console.WriteLine(@event.ToString());

        return Task.CompletedTask;
    }
}