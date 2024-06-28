namespace Basket.Host.Configuration;

public class RedisConfiguration
{
    public string Host { get; init; } = null!;
    public TimeSpan CacheTimeout { get; init; }
}