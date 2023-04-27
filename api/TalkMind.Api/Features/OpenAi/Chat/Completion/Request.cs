using System.Text.Json.Serialization;
using TalkMind.Api.Common;

namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public record Request
{
    public Request(Model model, IReadOnlyCollection<Message> messages)
    {
        Model = model;
        Messages = messages;
    }

    public Model Model { get; init; } = Model.GPT_4;

    public IReadOnlyCollection<Message> Messages { get; init; } = Array.Empty<Message>();

    private float _temperature = 1;

    public float Temperature
    {
        get => _temperature;
        init
        {
            if (value is < 0 or > 2)
                throw new ArgumentOutOfRangeException(
                    nameof(Temperature),
                    "Temperature must be between 0 and 2."
                );

            _temperature = value;
        }
    }

    private float _topP = 1;

    [JsonPropertyName("top_p")]
    public float TopP
    {
        get => _topP;
        init
        {
            if (value is < 0 or > 1)
                throw new ArgumentOutOfRangeException(
                    nameof(TopP),
                    "TopP must be between 0 and 1."
                );

            _topP = value;
        }
    }

    public int N { get; init; } = 1;

    public bool Stream { get; init; } = false;

    public StringOrArray? Stop { get; init; }

    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; init; }

    private float _presencePenalty;

    [JsonPropertyName("presence_penalty")]
    public float PresencePenalty
    {
        get => _presencePenalty;
        init
        {
            if (value is < -2 or > 2)
                throw new ArgumentOutOfRangeException(
                    nameof(_presencePenalty),
                    "PresencePenalty must be between -2 and 2."
                );

            _presencePenalty = value;
        }
    }

    private float _frequencyPenalty;

    [JsonPropertyName("frequency_penalty")]
    public float FrequencyPenalty
    {
        get => _frequencyPenalty;
        init
        {
            if (value is < -2 or > 2)
                throw new ArgumentOutOfRangeException(
                    nameof(_frequencyPenalty),
                    "FrequencyPenalty must be between -2 and 2."
                );

            _frequencyPenalty = value;
        }
    }

    [JsonPropertyName("logit_bias")]
    public IReadOnlyDictionary<string, LogitBias>? LogitBias { get; init; }

    public string User { get; init; } = string.Empty;
}
