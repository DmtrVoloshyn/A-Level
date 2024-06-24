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
    private readonly IDatabase _database;

    public CacheService(
        ILogger<CacheService> logger,
        IRedisCacheConnectionService redisCacheConnectionService,
        IOptions<RedisConfiguration> config,
        IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _redisCacheConnectionService = redisCacheConnectionService;
        _jsonSerializer = jsonSerializer;
        _database = GetRedisDatabase();
        _config = config.Value;
    }

    public Task AddOrUpdateAsync<T>(string key, T value)
        => AddOrUpdateInternalAsync(key, value);

    public async Task<T> GetAsync<T>(string key)
    {
        var serialized = await _database.StringGetAsync(key);

        return serialized.HasValue
            ? _jsonSerializer.Deserialize<T>(serialized.ToString())
            : throw new BusinessException($"Value with {key} not found");
    }
    
    private async Task AddOrUpdateInternalAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        expiry = expiry ?? _config.CacheTimeout;

        var cacheKey = key;
        var serialized = _jsonSerializer.Serialize(value);

        if (await _database.StringSetAsync(cacheKey, serialized, expiry))
        {
            _logger.LogInformation($"Cached value for key {key} cached");
        }
        else
        {
            _logger.LogInformation($"Cached value for key {key} updated");
        }
    }
    
    public async Task<bool> DeleteBasketAsync(string id)
    {
        return await _database.KeyDeleteAsync(id);
    }

    private IDatabase GetRedisDatabase() => _redisCacheConnectionService.Connection.GetDatabase();
}