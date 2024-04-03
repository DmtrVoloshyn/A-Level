namespace HttpPractice.Dtos.Responses;

public class BaseListResponse<T> : PageDto
    where T : class
{
    public List<T> Data { get; set; }
    public SupportDto Support { get; set; }
}