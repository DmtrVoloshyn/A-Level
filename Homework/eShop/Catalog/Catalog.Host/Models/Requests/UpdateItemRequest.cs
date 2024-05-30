using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

public class UpdateItemRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}
