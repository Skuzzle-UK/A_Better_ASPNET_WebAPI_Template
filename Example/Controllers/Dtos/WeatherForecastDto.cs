namespace Example.Controllers.Dtos;

public sealed class WeatherForecastDto : IDto
{
    public Guid? Id { get; set; } // Space between each property

    public DateOnly? Date { get; set; }

    public int? TemperatureC { get; set; }

    public int? TemperatureF { get; init; }

    public string? Summary { get; set; }
}
