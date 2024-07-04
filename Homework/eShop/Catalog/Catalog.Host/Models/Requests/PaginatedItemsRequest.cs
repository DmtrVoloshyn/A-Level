using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

[DataContract]
public class PaginatedItemsRequest
{
    [DataMember(Name = "page_index")]
    public int PageIndex { get; set; }

    [DataMember(Name = "page_size")]
    public int PageSize { get; set; }
}