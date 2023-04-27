using TalkMind.Api.Features.OpenAi.Chat.Completion;

namespace TalkMind.Api.Features.OpenAi.Chat;

public interface IOpenAiChatClient
{
    Task<Response> CreateCompletion(Request request, CancellationToken cancellationToken = default);
}
