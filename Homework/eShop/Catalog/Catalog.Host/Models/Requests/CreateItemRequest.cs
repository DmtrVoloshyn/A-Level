using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

[DataContract]
public class CreateItemRequest
{
    [DataMember(Name = "name")]
    public string Name { get; set; } = null!;

    [DataMember(Name = "description")]
    public string Description { get; set; } = null!;
    
    [DataMember(Name = "price")]
    public decimal Price { get; set; }

    [DataMember(Name = "picture_file_name")]
    public string? PictureFileName { get; set; }

    [DataMember(Name = "catalog_type_id")]
    public int CatalogTypeId { get; set; }

    [DataMember(Name = "catalog_brand_id")]
    public int CatalogBrandId { get; set; }

    [DataMember(Name = "available_stock")]
    public int AvailableStock { get; set; }
}