using Basket.Host.Models;

namespace Basket.Host.Dtos;

public class GetItemsResponseDto
{
    public CustomerBasket Basket { get; init; }
}