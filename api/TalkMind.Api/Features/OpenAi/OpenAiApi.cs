using TalkMind.Api.Common.DependencyInjection.Attributes;
using TalkMind.Api.Features.OpenAi.Chat;

namespace TalkMind.Api.Features.OpenAi;

[Register<IOpenAiApi>]
public class OpenAiApi : IOpenAiApi
{
    private readonly IOpenAiChatClient _openAiChatClient;

    public OpenAiApi(IOpenAiChatClient openAiChatClient) => _openAiChatClient = openAiChatClient;

    public IOpenAiChatClient Chat => _openAiChatClient;
}