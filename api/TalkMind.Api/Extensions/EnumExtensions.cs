using System.Reflection;
using System.Runtime.Serialization;

namespace TalkMind.Api.Extensions;

public static class EnumExtensions
{
    public static string? GetEnumMemberValue(this Enum @enum)
    {
        var enumType = @enum.GetType();
        var memberInfo = enumType.GetMember(@enum.ToString()).FirstOrDefault();
        var attribute = memberInfo?.GetCustomAttribute<EnumMemberAttribute>(false);
        var enumMemberValue = attribute?.Value;

        return enumMemberValue;
    }

    public static string? GetEnumMemberValueOrDefault(this Enum @enum) =>
        @enum.GetEnumMemberValue() ?? @enum.ToString();
}
