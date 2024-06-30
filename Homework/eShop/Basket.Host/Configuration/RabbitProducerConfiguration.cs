namespace Basket.Host.Configuration;

public class RabbitProducerConfiguration
{
    public string QueueName { get; set; }
    public string ExchangeName { get; set; }
}