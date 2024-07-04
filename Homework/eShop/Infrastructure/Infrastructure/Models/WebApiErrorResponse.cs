using System.Runtime.Serialization;

namespace Infrastructure.Models;

[DataContract]
public class WebApiErrorResponse
{
    public WebApiErrorResponse(int code, int? subCode, string? description)
    {
        Code = code;
        SubCode = subCode ?? default;
        Description = description ?? "";
    }

    [DataMember(Name = "name")]
    public int Code { get; }
    
    [DataMember(Name = "sub_code")]
    public int? SubCode { get; }

    [DataMember(Name = "description")] 
    public string? Description { get; }
}