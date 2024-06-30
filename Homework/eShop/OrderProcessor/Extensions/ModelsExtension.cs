using OrderProcessor.Data.Entities;
using OrderProcessor.Models;

namespace OrderProcessor.Extensions;

public static class ModelsExtension
{
    public static OrderEntity ToEntity(this Order model)
    {
        return new OrderEntity
        {
            BuyerGuid = model.BuyerGuid,
            OrderStatuses = model.OrderStatus,
            OrderGuid = model.Id,
            TotalPrice = model.TotalPrice,
            ProductIds = model.ProductIds
        };
    }

    public static BuyerEntity ToEntity(this Buyer model)
    {
        return new BuyerEntity
        {
            BuyerGuid = model.BuyerGuid,
            Name = model.BuyerName,
            SurName = model.BuyerSurName,
            Email = model.Email,
            FullAddress = model.FullAddress
        };
    }
}