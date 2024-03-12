using System.Text.Json.Serialization;

namespace HttpPractice.Dtos;

public class PageDto : SupportDto
{
    public int Page { get; set; }
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
    public int Total { get; set; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
}