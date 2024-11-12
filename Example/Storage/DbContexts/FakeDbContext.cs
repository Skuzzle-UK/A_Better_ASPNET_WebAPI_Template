#pragma warning disable // Not needed usually, just because of the comment below
using Example;
using Example.Storage;
using Example.Storage.DbContexts;
using Example.Storage.Entities;

namespace Example.Storage.DbContexts;

public sealed class FakeDbContext : IDbContext
{
    private readonly string[] MockData = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    // Complains because not awaited. Should not really be a task but in the real world database query would need to be async /nb
    public async Task<List<T>> GetManyAsync<T>(CancellationToken ct) where T : WeatherForecastEntity, new() =>
        Enumerable
            .Range(1, 5)
            .Select(index => new T
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = MockData[Random.Shared.Next(MockData.Length)]
            })
            .ToList();
}
