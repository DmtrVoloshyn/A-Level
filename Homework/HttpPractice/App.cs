using HttpPractice.Services.Abstractions;

namespace HttpPractice;

public class App
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    
    public App(IUserService userService, IResourceService resourceService)
    {
        _userService = userService;
        _resourceService = resourceService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(2);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var users = await _userService.GetUsers();
        var updatedUser = await _userService.UpdateUser("Vasyl", "engineer", 2);
        var updatedByPatchUser = await _userService.PatchUser(2, "Vasyl123");
        await _userService.DeleteUser(2);

        var resources = await _resourceService.GetResources();
        var resource = await _resourceService.GetResourceById(2);
    }
}