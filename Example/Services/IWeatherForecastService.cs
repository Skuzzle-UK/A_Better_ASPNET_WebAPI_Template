using Example.Models;
using FluentResults;
using System.Linq.Expressions;

namespace Example.Services;

public interface IWeatherForecastService
{
    Task<Result<Guid>> CreateAsync(WeatherForecast weatherForecast, CancellationToken ct);

    Task<Result> UpdateAsync(WeatherForecast weatherForecast, CancellationToken ct);

    Task<Result> DeleteAsync(Guid id, CancellationToken ct);

    Task<List<Result>> DeleteAsync(List<Guid> ids, CancellationToken ct);

    Task<Result<WeatherForecast>> GetByIdAsync(Guid id, CancellationToken ct);

    Task<Result<List<WeatherForecast>>> GetWeeklyForecastsAsync(CancellationToken ct);

    Task<Result<List<WeatherForecast>>> GetAsync(Expression<Func<WeatherForecast, bool>> predicate, CancellationToken ct);
}
