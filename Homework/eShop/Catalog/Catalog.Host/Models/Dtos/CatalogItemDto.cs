using System.Text.Json.Serialization;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    
    [JsonPropertyName("picture_url")]
    public string PictureUrl { get; set; }

    [JsonPropertyName("catalog_type")]
    public CatalogTypeDto CatalogType { get; set; }

    [JsonPropertyName("catalog_brand")]
    public CatalogBrandDto CatalogBrand { get; set; }

    [JsonPropertyName("available_stock")]
    public int AvailableStock { get; set; }
}
