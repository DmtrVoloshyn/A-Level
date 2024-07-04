namespace OrderProcessor.Configurations;

public class RabbitConsumerConfiguration
{
    public string QueueName { get; set; }
    public string ExchangeName { get; set; }
}
