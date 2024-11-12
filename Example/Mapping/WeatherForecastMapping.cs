using Example.Controllers.Dtos;
using Example.Models;
using Example.Storage.Entities;
using Mapster;

namespace Example.Mapping;

public sealed class WeatherForecastMapping // Seal classes if no plan for anything to derive from this
{
    public static void Configure()
    {
        TypeAdapterConfig<WeatherForecast, WeatherForecastDto>
            .NewConfig();
        TypeAdapterConfig<WeatherForecast, WeatherForecastEntity>.NewConfig();
    }
}
