using HttpPractice.Dtos.Responses;
using HttpPractice.Enums;
using HttpPractice.Extensions;
using HttpPractice.Options;
using HttpPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HttpPractice.Services;

public class ResourceService : IResourceService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;

    public ResourceService(IInternalHttpClientService httpClientService, 
        ILogger<UserService> logger, 
        IOptions<ApiOption> options)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }
    
    public async Task<List<ResourceDto>> GetResources()
    {
        var result = await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>
            ($"{_options.Host}{ReqresUrlTypes.Resource.GetDescriptionFromEnum()}", HttpMethod.Get);

        if (result.Data == null)
        {
            _logger.LogWarning($"Resources not found.");
        }
        
        _logger.LogInformation("Getting resources finished successfully");

        return result.Data;
    }

    public async Task<ResourceDto> GetResourceById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>
            ($"{_options.Host}{ReqresUrlTypes.Resource.GetDescriptionFromEnum()}{id}", HttpMethod.Get);
        
        if (result.Data == null)
        {
            _logger.LogWarning($"Resource not found.");
        }
        
        _logger.LogInformation("Getting resource finished successfully");

        return result.Data;
    }
    
}