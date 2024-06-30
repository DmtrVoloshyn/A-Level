namespace Basket.Host.Configuration;

public class RabbitProducersConfiguration
{
    public string RoutingKey { get; set; }
    public RabbitProducerConfiguration Producer { get; set; }
}
