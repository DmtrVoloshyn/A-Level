using System.ComponentModel;

namespace HttpPractice.Enums;

public enum ReqresUrlTypes
{
    [Description("api/users/")]
    User,
    [Description("api/unknown/")]
    Resource,
    [Description("api/register")]
    Register,
    [Description("api/login")]
    Login
}