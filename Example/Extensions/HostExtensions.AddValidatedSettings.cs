using Example.Settings;

namespace Example.Extensions;

public static partial class HostExtensions
{
    public static IServiceCollection AddValidatedSettings(this IServiceCollection services, HostBuilderContext hostContext)
    {
        services.AddOptions<WeatherSettings>()
            .Bind(hostContext.Configuration.GetSection(nameof(WeatherSettings)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}
