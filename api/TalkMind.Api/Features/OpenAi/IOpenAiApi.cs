using TalkMind.Api.Features.OpenAi.Chat;

namespace TalkMind.Api.Features.OpenAi;

public interface IOpenAiApi
{
    IOpenAiChatClient Chat { get; }
}
