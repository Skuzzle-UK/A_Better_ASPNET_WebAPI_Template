using Example.Storage;
using Example.Storage.Entities;

namespace Example.Extensions;

public static partial class HostExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IRepository<WeatherForecastEntity>, Repository<WeatherForecastEntity>>()
        ;
}
