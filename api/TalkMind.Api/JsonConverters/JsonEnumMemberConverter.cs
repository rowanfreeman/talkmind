using System.Text.Json;
using System.Text.Json.Serialization;
using TalkMind.Api.Extensions;

namespace TalkMind.Api.JsonConverters;

public class JsonEnumMemberConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : Enum
{
    public override TEnum? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var rawValue = reader.GetString();

        var enumMemberValueMap = typeToConvert
            .GetEnumValues()
            .OfType<TEnum>()
            .Select(x => (value: x, enumMemberValue: x.GetEnumMemberValueOrDefault()));

        (TEnum? value, string _) = enumMemberValueMap.FirstOrDefault(
            x => x.enumMemberValue == rawValue
        );

        return value ?? default;
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        var enumMemberValue = value.GetEnumMemberValueOrDefault();

        writer.WriteStringValue(enumMemberValue);
    }
}
