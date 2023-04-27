namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public record Message
{
    public Role Role { get; init; } = Role.User;

    public string Content { get; init; } = string.Empty;
}
