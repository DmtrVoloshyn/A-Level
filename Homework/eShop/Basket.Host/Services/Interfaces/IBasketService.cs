using Basket.Host.Models;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task Add(Guid userId, string data);
    Task<GetItemsResponseDto> Get(Guid userId);
}