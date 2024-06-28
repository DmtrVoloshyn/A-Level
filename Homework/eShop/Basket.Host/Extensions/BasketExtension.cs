using Basket.Host.Models;
using Infrastructure.Models.Dtos;

namespace Basket.Host.Extensions;

public static class BasketExtension
{
    public static BasketItemDto ToDto(this BasketItem item)
    {
        return new BasketItemDto
        {
            Name = item.Name,
            ProductId = item.ProductId,
            PictureUrl = item.PictureUrl,
            Price = item.Price,
            Quantity = item.Quantity,
        };
    }
}