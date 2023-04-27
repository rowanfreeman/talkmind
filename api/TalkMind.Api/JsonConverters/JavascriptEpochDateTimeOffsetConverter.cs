using System.Text.Json;
using System.Text.Json.Serialization;

namespace TalkMind.Api.JsonConverters;

public class JavascriptEpochDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var raw = reader.GetInt32();

        return DateTimeOffset.UnixEpoch.AddSeconds(raw);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset value,
        JsonSerializerOptions options
    ) => writer.WriteNumberValue(value.ToUnixTimeSeconds());
}
