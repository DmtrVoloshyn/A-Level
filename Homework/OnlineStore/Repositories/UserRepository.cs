using Entities;

namespace Repositories;

public class UserRepository
{
    private readonly UserEntity[] _mockStorage = new UserEntity[100];
    private int _mockStorageCursor = 0;

    public string AddUser(string firstName, string lastName, string email)
    {
        var user = new UserEntity()
        {
            UserId = Guid.NewGuid().ToString(),
            UserFirstName = firstName,
            UserLastName = lastName,
            UserEmail = email
        };

        _mockStorage[_mockStorageCursor] = user;
        _mockStorageCursor++;
        return user.UserId;
    }

    public UserEntity GetUser(string id)
    {
        foreach (var item in _mockStorage)
        {
            if (item.UserId == id)
            {
                return item;
            }
        }

        return null;
    }
}