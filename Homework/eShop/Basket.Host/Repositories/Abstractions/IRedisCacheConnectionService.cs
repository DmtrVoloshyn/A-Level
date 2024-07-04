using StackExchange.Redis;

namespace Basket.Host.Repositories.Abstractions;

public interface IRedisCacheConnectionService
{
    public IConnectionMultiplexer Connection { get; }
}