using System.Text.Json.Serialization;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogBrandDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }
}