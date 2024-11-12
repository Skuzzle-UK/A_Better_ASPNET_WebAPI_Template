using Example.Services;

namespace Example.Extensions;

public static partial class HostExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<IWeatherForecastService, WeatherForecastService>()
        ;
}
