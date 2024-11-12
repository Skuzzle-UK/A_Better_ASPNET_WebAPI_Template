using Example.Settings;
using Example.Storage;
using Example.Storage.Entities;
using Microsoft.Extensions.Options;

namespace Example.Services;

public sealed partial class WeatherForecastService : IWeatherForecastService
{
    private readonly IRepository<WeatherForecastEntity> _repository;
    private readonly WeatherSettings _settings;

    public WeatherForecastService(
        IRepository<WeatherForecastEntity> repository,
        IOptions<WeatherSettings> settings)
    {
        _repository = repository;
        _settings = settings.Value;
    }
}
