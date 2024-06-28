using Basket.Host.Configuration;
using Basket.Host.Repositories.Abstractions;
using StackExchange.Redis;

namespace Basket.Host.Repositories;

public class RedisCacheConnectionService : IRedisCacheConnectionService
{
    private readonly Lazy<ConnectionMultiplexer> _connectionLazy;
    private bool _disposed;

    public RedisCacheConnectionService(
        IOptions<RedisConfiguration> config)
    {
        var redisConfigurationOptions = ConfigurationOptions.Parse(config.Value.Host);
        _connectionLazy =
            new Lazy<ConnectionMultiplexer>(() 
                => ConnectionMultiplexer.Connect(redisConfigurationOptions));
    }

    public IConnectionMultiplexer Connection => _connectionLazy.Value;

    public void Dispose()
    {
        if (!_disposed)
        {
            Connection.Dispose();
            _disposed = true;
        }
    }
}