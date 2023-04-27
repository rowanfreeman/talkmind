namespace TalkMind.Api.Configuration.Extensions;

internal static class BindOptionsExtensions
{
    internal static IServiceCollection BindOptions<TOptions>(
        this IServiceCollection services,
        string configurationSectionPath
    )
        where TOptions : class
    {
        services.AddOptions<TOptions>().BindConfiguration(configurationSectionPath);

        return services;
    }
}