using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

public class CreateItemRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("picture_file_name")]
    public string? PictureFileName { get; set; }

    [JsonPropertyName("catalog_type_id")]
    public int CatalogTypeId { get; set; }

    [JsonPropertyName("catalog_brand_id")]
    public int CatalogBrandId { get; set; }

    [JsonPropertyName("available_stock")]
    public int AvailableStock { get; set; }
}