namespace Catalog.Host.Models.Response;

public class AddSomeItemResponse<T>
{
    public T Id { get; set; } = default(T) !;
}