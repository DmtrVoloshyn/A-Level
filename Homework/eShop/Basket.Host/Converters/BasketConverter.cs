using Basket.Host.Dtos;
using Basket.Host.Models;

namespace Basket.Host.Converters;

public static class BasketConverter
{
    public static GetItemsResponseDto ToDto(this CustomerBasket basket)
    {
        return new GetItemsResponseDto
        {
            Basket = basket
        };
    }
}