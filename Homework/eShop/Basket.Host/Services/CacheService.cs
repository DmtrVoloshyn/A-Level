using Basket.Host.Configuration;
using Basket.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using StackExchange.Redis;

namespace Basket.Host.Services;

public class CacheService : ICacheService
{
    private readonly ILogger<CacheService> _logger;
    private readonly IRedisCacheConnectionService _redisCacheConnectionService;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly RedisConfiguration _config;

    public CacheService(
        ILogger<CacheService> logger,
        IRedisCacheConnectionService redisCacheConnectionService,
        IOptions<RedisConfiguration> config,
        IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _redisCacheConnectionService = redisCacheConnectionService;
        _jsonSerializer = jsonSerializer;
        _config = config.Value;
    }

    public Task AddOrUpdateAsync<T>(string key, T value)
        => AddOrUpdateInternalAsync(key, value);

    public async Task<T> GetAsync<T>(string key)
    {
        var redis = GetRedisDatabase();
        
        var serialized = await redis.StringGetAsync(key);

        return serialized.HasValue
            ? _jsonSerializer.Deserialize<T>(serialized.ToString())
            : throw new BusinessException($"Value with {key} not found");
    }
    
    private async Task AddOrUpdateInternalAsync<T>(string key, T value,
        IDatabase redis = null!, TimeSpan? expiry = null)
    {
        redis = redis ?? GetRedisDatabase();
        expiry = expiry ?? _config.CacheTimeout;

        var cacheKey = key;
        var serialized = _jsonSerializer.Serialize(value);

        if (await redis.StringSetAsync(cacheKey, serialized, expiry))
        {
            _logger.LogInformation($"Cached value for key {key} cached");
        }
        else
        {
            _logger.LogInformation($"Cached value for key {key} updated");
        }
    }

    private IDatabase GetRedisDatabase() => _redisCacheConnectionService.Connection.GetDatabase();
}