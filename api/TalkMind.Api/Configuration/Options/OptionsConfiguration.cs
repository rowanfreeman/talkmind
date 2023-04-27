using TalkMind.Api.Configuration.Extensions;

namespace TalkMind.Api.Configuration.Options;

internal static class OptionsConfiguration
{
    internal static IServiceCollection AddAllOptions(this IServiceCollection services)
    {
        services
            .BindOptions<AzureCognitiveServicesOptions>("AzureCognitiveServices")
            .BindOptions<OpenAiOptions>("OpenAi");

        return services;
    }
}