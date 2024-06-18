namespace Basket.Host.Configuration;

public class RedisConfiguration
{
    public string Host { get; set; } = null!;
    public TimeSpan CacheTimeout { get; set; }
}