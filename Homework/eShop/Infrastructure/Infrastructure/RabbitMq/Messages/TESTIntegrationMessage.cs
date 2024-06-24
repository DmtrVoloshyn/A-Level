using Infrastructure.RabbitMq.Abstractions;

namespace Infrastructure.RabbitMq.Messages;

public class TESTIntegrationMessage : IntegrationEvent
{
    public string Hello { get; set; }
}