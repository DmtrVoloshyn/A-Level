namespace Basket.Host.Repositories.Abstractions;

public interface ICacheRepository
{
    Task AddOrUpdateAsync<T>(string key ,T value);
    Task<T> GetAsync<T>(string key);
    Task<bool> DeleteBasketAsync(string id);
}