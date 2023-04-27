using Microsoft.Extensions.Options;
using System.Text.Json;
using TalkMind.Api.Configuration.Options;
using TalkMind.Api.Features.OpenAi.Chat.Completion;

namespace TalkMind.Api.Features.OpenAi.Chat;

public class OpenAiChatClient : IOpenAiChatClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly OpenAiOptions _openAiOptions;

    public OpenAiChatClient(
        HttpClient httpClient,
        IOptions<OpenAiOptions> options,
        JsonSerializerOptions jsonSerializerOptions
    )
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
        _openAiOptions = options.Value;
    }

    public async Task<Response> CreateCompletion(
        Request request,
        CancellationToken cancellationToken = default
    )
    {
        var uri = _openAiOptions.ChatCompletionsUri;
        var clientResponse = await _httpClient.PostAsJsonAsync(
            uri,
            request,
            _jsonSerializerOptions,
            cancellationToken
        );

        var response = await clientResponse
            .EnsureSuccessStatusCode()
            .Content.ReadFromJsonAsync<Response>(_jsonSerializerOptions, cancellationToken);

        return response ?? new();
    }
}