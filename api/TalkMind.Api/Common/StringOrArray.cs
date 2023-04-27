using System.Collections;
using System.Text.Json.Serialization;
using TalkMind.Api.JsonConverters;

namespace TalkMind.Api.Common;

[JsonConverter(typeof(StringOrArrayConverter))]
public struct StringOrArray
{
    private string? _stringValue = string.Empty;
    private IEnumerable? _arrayValue = string.Empty;

    private StringOrArray(string value)
    {
        _stringValue = value;
        _arrayValue = null;
    }

    public static implicit operator StringOrArray(string value) => new(value);

    private StringOrArray(Array value)
    {
        _arrayValue = value;
        _stringValue = null;
    }

    public static implicit operator StringOrArray(Array value) => new(value);

    public override string ToString() =>
        _stringValue?.ToString() ?? _arrayValue?.ToString() ?? string.Empty;

    public override int GetHashCode() =>
        _stringValue?.GetHashCode()
        ?? _arrayValue?.GetHashCode()
        ?? throw new NullReferenceException("StringOrArray has no internal value.");
}