using System.Runtime.Serialization;

namespace HttpPractice.Dtos;

[DataContract]
public class AuthorizationRequest
{
    [DataMember(Name = "email")]
    public string Email { get; set; }
    
    [DataMember(Name = "password")]
    public string Password { get; set; }
}