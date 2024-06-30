using System.Text.Json.Serialization;
using Infrastructure.Enums;
using OrderProcessor.Enums;

namespace OrderProcessor.Models;

public class Order
{
    public Order(string guid, 
        string buyerGuid, 
        OrderStatuses orderStatus,
        PaymentTypes paymentType,
        decimal totalPrice,
        IEnumerable<int> productIds
        )
    {
        Id = guid;
        BuyerGuid = buyerGuid;
        OrderStatus = orderStatus;
        PaymentType = paymentType;
        TotalPrice = totalPrice;
        ProductIds = productIds;
    }
    
    [JsonPropertyName("order_guid")]
    public string Id { get; set; }
    
    [JsonPropertyName("buyer_guid")]
    public string BuyerGuid { get; set; }
    
    [JsonPropertyName("order_status")]
    public OrderStatuses OrderStatus { get; set; }
    
    [JsonPropertyName("payment_type")]
    public PaymentTypes PaymentType { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    [JsonPropertyName("order_items")]
    public IEnumerable<int> ProductIds { get; set; }
}
