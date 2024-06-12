using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

[DataContract]
public class UpdateItemRequest
{
    [DataMember(Name = "id")]
    public int Id { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; } = null!;

    [DataMember(Name = "description")]
    public string Description { get; set; } = null!;

    [DataMember(Name = "price")]
    public decimal Price { get; set; }
}
