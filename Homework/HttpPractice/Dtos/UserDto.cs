using Newtonsoft.Json;

namespace HttpPractice.Dtos;

public class UserDto : SupportDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    [JsonProperty(PropertyName = "first_name")]
    public string FirstName { get; set; }
    [JsonProperty(PropertyName = "last_name")]
    public string LastName { get; set; }
    public string Avatar { get; set; }
}