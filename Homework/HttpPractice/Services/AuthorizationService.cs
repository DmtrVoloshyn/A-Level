using HttpPractice.Dtos;
using HttpPractice.Dtos.Responses;
using HttpPractice.Enums;
using HttpPractice.Extensions;
using HttpPractice.Options;
using HttpPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HttpPractice.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IInternalHttpClientService _httpClient;
    private readonly ILogger<AuthorizationService> _logger;
    private readonly ApiOption _options;

    public AuthorizationService(
        IInternalHttpClientService httpClientService,
        ILogger<AuthorizationService> logger,
        IOptions<ApiOption> options)
    {
        _httpClient = httpClientService;
        _logger = logger;
        _options = options.Value;
    }
        
    public async Task<AuthorizationResponse> RegisterUser(string email, string password)
    {
        var result = await _httpClient.SendAsync<AuthorizationResponse, AuthorizationRequest>
        ($"{_options.Host}{ReqresUrlTypes.Register.GetDescriptionFromEnum()}", HttpMethod.Post,
            new AuthorizationRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id {result.Id} successfully register");
        }

        return result;
    }

    public async Task<AuthorizationResponse> LoginUser(string email, string password)
    {
        var result = await _httpClient.SendAsync<AuthorizationResponse, AuthorizationRequest>
        ($"{_options.Host}{ReqresUrlTypes.Login.GetDescriptionFromEnum()}", HttpMethod.Post,
            new AuthorizationRequest()
            {
                Email = email,
                Password = password
            });

        if (result != null)
        {
            _logger.LogInformation($"User token: {result.Token}");
        }

        return result;
    }
}