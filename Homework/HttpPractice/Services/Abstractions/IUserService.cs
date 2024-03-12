using HttpPractice.Dtos;
using HttpPractice.Dtos.Responses;

namespace HttpPractice.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job); 
    Task<List<UserDto>> GetUsers();
    Task<UserResponse> UpdateUser(string name, string job, int id);
    Task<UserResponse> PatchUser(int id, string name = null!, string job = null!);
    Task DeleteUser(int id);
}