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

    [DataMember(Name = "name")]
    public int Code { get; }
    
    [DataMember(Name = "sub_code")]
    public int SubCode { get; }
    
    [DataMember(Name = "description")]
    public string Description { get; }
}