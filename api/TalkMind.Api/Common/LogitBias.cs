namespace TalkMind.Api.Common;

public struct LogitBias
{
    private int _value;

    public LogitBias(int value)
    {
        if (value is < -100 or > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "");

        _value = value;
    }

    public static implicit operator LogitBias(int value) => new(value);

    public override string ToString() => _value.ToString();
}
