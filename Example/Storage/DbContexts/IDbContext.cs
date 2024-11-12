using Example.Storage.Entities;

namespace Example.Storage.DbContexts;

public interface IDbContext
{
    Task<List<T>> GetManyAsync<T>(CancellationToken ct) where T : WeatherForecastEntity, new();
}
