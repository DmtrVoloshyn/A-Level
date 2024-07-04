namespace Infrastructure.RabbitMq.Messages;

public class IntegrationEvent
{
    public IntegrationEvent(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
