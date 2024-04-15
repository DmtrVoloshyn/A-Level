using System.ComponentModel;
using System.Reflection;
using HttpPractice.Enums;

namespace HttpPractice.Extensions;

public static class HttpExtensions
{
    public static string GetDescriptionFromEnum(this ReqresUrlTypes enumValue)
    {
        var type = enumValue.GetType();
        MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
        if (memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        
        return enumValue.ToString(); 
    }
}