using Example.Controllers.Dtos;

namespace Example.Models;

public sealed class WeatherForecast : IModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556); // Methods after properties, including expression body type

    // Domain model should contain logic for this object only.
    public WeatherForecastDto ToDto() => new WeatherForecastDto() // Bad example as we have mapping.. but was brain dead at 22:09
    {
        Id = Id,
        Date = Date,
        Summary = Summary,
        TemperatureC = TemperatureC,
        TemperatureF = TemperatureF
    };
}
