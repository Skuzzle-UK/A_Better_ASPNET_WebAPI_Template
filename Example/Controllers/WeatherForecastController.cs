using Example.Controllers.Dtos;
using Example.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Example.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService) // One line only because one dependency injected
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public async Task<ActionResult<List<WeatherForecastDto>>> GetAsync(CancellationToken ct)
    {
        var forecast = await _weatherForecastService.GetWeeklyForecastsAsync(ct);

        return forecast.IsSuccess
            ? Ok(forecast.Value.Adapt<List<WeatherForecastDto>>())
            : StatusCode((int)HttpStatusCode.InternalServerError);
    }
}
