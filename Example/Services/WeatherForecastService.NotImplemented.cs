using Example.Models;
using FluentResults;
using System.Linq.Expressions;

namespace Example.Services;

public sealed partial class WeatherForecastService : IWeatherForecastService
{
    public Task<Result<Guid>> CreateAsync(WeatherForecast weatherForecast, CancellationToken ct) => throw new NotImplementedException();

    public Task<Result> DeleteAsync(Guid id, CancellationToken ct) => throw new NotImplementedException(); // Grouped polymorphic methods

    public Task<List<Result>> DeleteAsync(List<Guid> ids, CancellationToken ct) => throw new NotImplementedException();

    public Task<Result<List<WeatherForecast>>> GetAsync(Expression<Func<WeatherForecast, bool>> predicate, CancellationToken ct) => throw new NotImplementedException();

    public Task<Result<WeatherForecast>> GetByIdAsync(Guid id, CancellationToken ct) => throw new NotImplementedException();

    public Task<Result> UpdateAsync(WeatherForecast weatherForecast, CancellationToken ct) => throw new NotImplementedException();
}
