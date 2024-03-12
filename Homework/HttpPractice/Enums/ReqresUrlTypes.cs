using System.ComponentModel;

namespace HttpPractice.Enums;

public enum ReqresUrlTypes
{
    [Description("api/users/")]
    User,
    [Description("api/unknown/")]
    Resource
}