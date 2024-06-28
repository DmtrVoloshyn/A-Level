#pragma warning disable CS8618
using Infrastructure.Enums;
using OrderProcessor.Enums;

namespace OrderProcessor.Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public string OrderGuid { get; set; }
    public int BuyerId { get; set; }
    public OrderStatuses OrderStatuses { get; set; }
    public PaymentTypes PaymentType { get; set; }
    public IEnumerable<int> ProductIds { get; set; }
    public decimal TotalPrice { get; set; }
    
    public BuyerEntity Buyer { get; set; }
}