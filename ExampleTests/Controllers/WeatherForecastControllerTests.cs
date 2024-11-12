// Tests should cover every possible path through every class method.
// Tests must cover expected failure results as well as success results.

using Example.Controllers;
using Example.Controllers.Dtos;
using Example.Models;
using Example.Services;
using FluentAssertions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace ExampleTests.Controllers;

[TestFixture]
public sealed class WeatherForecastControllerTests
{
    private readonly WeatherForecastController _sut; // system under test. Critically this class should only have 1 sut.... p.s this comment is too long for this line.. .... aghhhhh horrible to look at, prefer comments above line if longer than a couple of words
                                                     //Note the linebreak between _sut and mocks ;) and hideous comment positioning
    private readonly Mock<IWeatherForecastService> _weatherForecastControllerMock;

    public WeatherForecastControllerTests()
    {
        _weatherForecastControllerMock = new();
        // Perform any class wide setup of this mock here.

        _sut = new(_weatherForecastControllerMock.Object);
    }

    [SetUp]
    public void Init()
    {
        // Anything that is setup or reconfigured before each test back to a specific value
    }

    [Test]
    public async Task GetAsync_GetWeeklyForecastSuccessful_ReturnsOkWithListOfWeatherForecastDto()
    {
        // arrange
        var forecast = new List<WeatherForecast>()
        {
            new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(
                    DateTimeOffset.UtcNow.Year, // Prefer DateTimeOffset.UtcNow for consistent times across regions
                    DateTimeOffset.UtcNow.Month,
                    DateTimeOffset.UtcNow.Day),
                Summary = "A Summary",
                TemperatureC = 32
            },
            new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(
                    DateTimeOffset.UtcNow.Year,
                    DateTimeOffset.UtcNow.Month,
                    DateTimeOffset.UtcNow.Day),
                Summary = "A N Other Summary",
                TemperatureC = 23
            }
        };

        _weatherForecastControllerMock
            .Setup(x => x.GetWeeklyForecastsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(forecast.ToList()));

        // act
        var result = await _sut.GetAsync(CancellationToken.None);

        var actionResult = result.Result as OkObjectResult; // Required casts to assert values
        var value = actionResult!.Value as List<WeatherForecastDto>;

        // assert
        result.Should().BeOfType<ActionResult<List<WeatherForecastDto>>>();
        value!.Count.Should().Be(2);
        value[0].TemperatureC.Should().Be(32); // To confirm the correct dto list is returned
    }

    [Test]
    public async Task GetAsync_GetWeeklyForecastFailes_ReturnsInternalServerError()
    {
        // arrange
        _weatherForecastControllerMock
            .Setup(x => x.GetWeeklyForecastsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Fail(new Error("Exception!")));

        // act
        var result = await _sut.GetAsync(CancellationToken.None);

        var actionResult = result.Result as StatusCodeResult;

        // assert
        result.Should().BeOfType<ActionResult<List<WeatherForecastDto>>>();
        actionResult!.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
    }
}