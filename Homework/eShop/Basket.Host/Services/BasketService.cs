using Basket.Host.Models;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
    
    public async Task Add(Guid userId, string data)
    {
        await _cacheService.AddOrUpdateAsync(userId.ToString(), data);
    }

    public async Task<GetItemsResponseDto> Get(Guid userId)
    {
        var result = await _cacheService.GetAsync<string>(userId.ToString());
        return new GetItemsResponseDto() { Data = result };
    }
}