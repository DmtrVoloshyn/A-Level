using System.Text.Json.Serialization;
using Infrastructure.Enums;
using OrderProcessor.Enums;

namespace OrderProcessor.Models;

public class Order
{
    public Order(string id, 
        string buyerId, 
        OrderStatuses orderStatus,
        PaymentTypes paymentType,
        IEnumerable<OrderItem> items
        )
    {
        Id = id;
        BuyerId = buyerId;
        OrderStatus = orderStatus;
        PaymentType = paymentType;
        Items = items;
    }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("buyer_id")]
    public string BuyerId { get; set; }
    
    [JsonPropertyName("order_status")]
    public OrderStatuses OrderStatus { get; set; }
    
    [JsonPropertyName("payment_type")]
    public PaymentTypes PaymentType { get; set; }
    
    [JsonPropertyName("order_items")]
    public IEnumerable<OrderItem> Items { get; set; }
}
