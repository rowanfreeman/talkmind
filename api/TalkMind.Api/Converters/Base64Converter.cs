namespace TalkMind.Api.Converters;

internal static class Base64Converter
{
    internal static byte[]? GetBytes(string base64String)
    {
        try
        {
            return Convert.FromBase64String(base64String);
        }
        catch (FormatException)
        {
            return null;
        }
    }
}
