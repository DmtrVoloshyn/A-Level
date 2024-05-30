using System.Text.Json.Serialization;

#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class CatalogTypeDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}