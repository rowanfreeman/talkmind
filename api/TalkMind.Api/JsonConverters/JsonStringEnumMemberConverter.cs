using System.Text.Json;
using System.Text.Json.Serialization;

namespace TalkMind.Api.JsonConverters;

public class JsonStringEnumMemberConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var genericType = typeof(JsonEnumMemberConverter<>).GetGenericTypeDefinition();
        var converterType = genericType.MakeGenericType(typeToConvert);
        var converter = Activator.CreateInstance(converterType) as JsonConverter;

        return converter;
    }
}
