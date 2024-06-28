using System.Runtime.Serialization;

namespace OrderProcessor.Models;

[DataContract]
public class OrderItem
{
    public OrderItem(int productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}