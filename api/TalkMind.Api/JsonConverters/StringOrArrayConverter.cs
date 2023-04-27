using System.Text.Json;
using System.Text.Json.Serialization;
using TalkMind.Api.Common;

namespace TalkMind.Api.JsonConverters;

public class StringOrArrayConverter : JsonConverter<StringOrArray>
{
    public override StringOrArray Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }

    public override void Write(
        Utf8JsonWriter writer,
        StringOrArray value,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }
}
