using Example.Mapping;

namespace Example.Extensions;

public static partial class HostExtensions
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        WeatherForecastMapping.Configure();

        return services;
    }
}
