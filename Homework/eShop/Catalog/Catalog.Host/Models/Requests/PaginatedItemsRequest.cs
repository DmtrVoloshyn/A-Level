using System.Text.Json.Serialization;

namespace Catalog.Host.Models.Requests;

public class PaginatedItemsRequest
{
    [JsonPropertyName("page_index")]
    public int PageIndex { get; set; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
}