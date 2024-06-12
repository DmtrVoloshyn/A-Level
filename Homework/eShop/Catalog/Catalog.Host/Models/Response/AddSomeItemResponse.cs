using System.Runtime.Serialization;

namespace Catalog.Host.Models.Response;

[DataContract]
public class AddSomeItemResponse<T>
{
    [DataMember(Name = "id")]
    public T Id { get; set; } = default(T)!;
}