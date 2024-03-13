using HttpPractice.Dtos;
using HttpPractice.Dtos.Requests;
using HttpPractice.Dtos.Responses;
using HttpPractice.Enums;
using HttpPractice.Extensions;
using HttpPractice.Options;
using HttpPractice.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HttpPractice.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _options = options.Value;
        _logger = logger;
    }
    
    public async Task<UserDto> GetUserById(int id)
    {
        var result = await _httpClientService.SendAsync<BaseResponse<UserDto>, object>
            ($"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}{id}", HttpMethod.Get);

        if (result.Data != null)
        {
            _logger.LogInformation($"User with id = {result.Data.Id} was found. His name is {result.Data.FirstName}");
        }

        return result.Data;
    }
    
    public async Task<List<UserDto>> GetUsers()
    {
        var result = await _httpClientService.SendAsync<BaseListResponse<UserDto>, object>
            ($"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}?page=2", HttpMethod.Get);

        if (result.Data != null)
        {
            _logger.LogInformation($"Users with page id = {result.Page} was found");
        }

        return result.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>
        ($"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}", HttpMethod.Post,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result.Id} was created");
        }

        return result;
    }

    public async Task<UserResponse> UpdateUser(string name, string job, int id)
    {
        var result = await _httpClientService.SendAsync<UserResponse, UserRequest>
            ($"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}{id}", HttpMethod.Put, 
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {id} was updated. New name is {result.Name}");
        }

        return result;
    }
    
    public async Task<UserResponse> PatchUser(int id, string name = null!, string job = null!)
    {
        var url = $"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}{id}";
        var request = new UserRequest();

        if (name != null!)
        {
            request.Name = name;
        }

        if (job != null!)
        {
            request.Job = job;
        }

        var result = await _httpClientService.SendAsync<UserResponse, object>(url, HttpMethod.Patch, request);

        if (result != null!)
        {
            _logger.LogInformation($"User with id = {id} was updated. New data: {result.Name}, {result.Job}");
        }

        return result!;
    }
    
    public async Task DeleteUser(int id)
    {
        var result = await _httpClientService.SendAsync<object, object>
            ($"{_options.Host}{ReqresUrlTypes.User.GetDescriptionFromEnum()}{id}", HttpMethod.Delete);
        
        _logger.LogInformation($"User with id = {id} was deleted at {DateTime.UtcNow}");
    }
}