using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Infrastructure.Enums;

namespace Basket.Host.Dtos;

[DataContract]
public class CreateOrderRequestDto
{
    [JsonPropertyName("name")]
    public string BuyerName { get; set; }
    
    [JsonPropertyName("sur_name")]
    public string BuyerSurName { get; set; }
    
    public string Email { get; set; }
    
    [JsonPropertyName("address")]
    public string FullAddress { get; set; }
    
    [JsonPropertyName("payment_type")]
    public PaymentTypes PaymentType { get; set; }
}
