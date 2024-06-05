using System.Runtime.Serialization;

namespace Catalog.Host.Models.Response;

[DataContract]
public class WebApiErrorResponse
{
    public WebApiErrorResponse(int code, int subCode, string? description)
    {
        Code = code;
        SubCode = subCode;
        Description = description ?? "";
    }

    [DataMember]
    public int Code { get; }
    [DataMember]
    public int SubCode { get; }
    [DataMember]
    public string Description { get; }
}