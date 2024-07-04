using System.Runtime.Serialization;

namespace Catalog.Host.Models.Response;

[DataContract]
public class PaginatedItemsResponse<T>
{
    [DataMember(Name = "page_index")]
    public int PageIndex { get; init; }
    
    [DataMember(Name = "page_size")]
    public int PageSize { get; init; }
    
    [DataMember(Name = "count")]
    public long Count { get; init; }
    
    [DataMember(Name = "data")]
    public IEnumerable<T> Data { get; init; } = null!;
}
