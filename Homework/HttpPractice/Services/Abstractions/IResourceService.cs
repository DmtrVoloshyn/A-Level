using HttpPractice.Dtos.Responses;

namespace HttpPractice.Services.Abstractions;

public interface IResourceService
{
    Task<List<ResourceDto>> GetResources();
    Task<ResourceDto> GetResourceById(int id);
}