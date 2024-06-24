using Basket.Host.Dtos;
using Basket.Host.Models;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task Add(BasketItem item);
    Task<GetItemsResponseDto> Get(Guid userId);
}