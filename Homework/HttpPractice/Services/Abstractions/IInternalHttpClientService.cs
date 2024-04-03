namespace HttpPractice.Services.Abstractions;

public interface IInternalHttpClientService
{
    Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null!)
        where TRequest : class;
}