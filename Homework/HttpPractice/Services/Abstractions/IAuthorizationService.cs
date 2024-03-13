using HttpPractice.Dtos.Responses;

namespace HttpPractice.Services.Abstractions;

public interface IAuthorizationService
{
    Task<AuthorizationResponse> RegisterUser(string email, string password);
    Task<AuthorizationResponse> LoginUser(string email, string password);
}