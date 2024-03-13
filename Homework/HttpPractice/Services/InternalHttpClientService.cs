using System.Text;
using HttpPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HttpPractice.Services;

public class InternalHttpClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<IInternalHttpClientService> _logger;

    public InternalHttpClientService(IHttpClientFactory clientFactory, ILogger<IInternalHttpClientService> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }
    
    public async Task<TResponse> SendAsync<TResponse, TRequest>(
        string url, 
        HttpMethod method, 
        TRequest content = default(TRequest)!)
        where TRequest : class
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

            return response;
        }
        
        _logger.LogError(await result.Content.ReadAsStringAsync());

        return default(TResponse)!;
    }
}