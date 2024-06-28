using Basket.Host.Dtos;
using Basket.Host.Models;

namespace Basket.Host.Services.Abstractions;

public interface IBasketService
{
    Task AddOrUpdateBasket(CustomerBasket item, string userId);
    Task<CustomerBasket> GetBasket(string userId);
    Task<bool> DeleteBasket(string userId);
    Task<string> CreateOrder(CustomerBasket customerBasket, CreateOrderRequestDto requestDto);
}