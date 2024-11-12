using Example.Controllers.Dtos;

namespace Example.Extensions;

// Extension methods for DTO's or entities to keep their internal logic minimal.
// Also use extension methods for adding functionality to classes you dont own.
public static class WeatherForecastDtoExtensions
{
    public static WeatherForecastDto CloudSeed(this WeatherForecastDto weatherForecast)
    {
        // TODO: Should also alter TemperatureF as DTO contains no logic /nb
        // This method is probably a terrible example as really a DTO should ever need this type of logic... but hey ho.
        // Dont leave todos unless it is covered by another story that has already been created.

        weatherForecast.TemperatureC -= 5;
        return weatherForecast;
    }
}
