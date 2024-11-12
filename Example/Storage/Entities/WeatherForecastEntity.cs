namespace Example.Storage.Entities;

public class WeatherForecastEntity : IEntity, ISoftDelete
{
    public int TemperatureC { get; set; } // Unique to class params first. Interface params after in order of interface

    public string? Summary { get; set; }

    public DateOnly Date { get; set; }

    public Guid Id { get; set; }

    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedOn { get; set; }

    public DateTimeOffset? DeletedOn { get; set; }

    // P.S all comments have space after // so we cant have //comment, must be // comment
    public WeatherForecastEntity()
    {
    }
}
