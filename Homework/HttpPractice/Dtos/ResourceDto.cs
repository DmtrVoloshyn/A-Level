using System.Text.Json.Serialization;

namespace HttpPractice.Dtos.Responses;

public class ResourceDto : SupportDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    [JsonPropertyName("pantone_value")]
    public string PantoneValue { get; set; }
}