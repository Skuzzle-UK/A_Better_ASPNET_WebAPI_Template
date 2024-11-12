using Example.Models;
using FluentResults;
using Mapster;

namespace Example.Services;

public sealed partial class WeatherForecastService : IWeatherForecastService
{
    public async Task<Result<List<WeatherForecast>>> GetWeeklyForecastsAsync(CancellationToken ct)
    {
        var result = await _repository.GetManyAsync(ct); // Would usually have a predicate but this is simple example

        return result.IsSuccess
            ? Result.Ok(result.Value.Adapt<List<WeatherForecast>>())
            : Result.Fail(result.Errors);
    }
}
