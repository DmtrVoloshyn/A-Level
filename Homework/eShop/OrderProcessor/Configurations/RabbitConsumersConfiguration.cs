namespace OrderProcessor.Configurations;

public class RabbitConsumersConfiguration
{
    public string RoutingKey { get; set; }
    public RabbitConsumerConfiguration Consumers { get; set; }
}
