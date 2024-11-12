using Example.Controllers.Dtos;
using Example.Models;
using FluentAssertions;

namespace ExampleTests.Models;

[TestFixture]
public sealed class WeatherForecastTests
{
    private readonly WeatherForecast _sut;

    public WeatherForecastTests()
    {
        _sut = new()
        {
            Id = Guid.NewGuid(),
            Date = new DateOnly(
                DateTimeOffset.UtcNow.Year,
                DateTimeOffset.UtcNow.Month,
                DateTimeOffset.UtcNow.Day),
            Summary = "A Summary",
            TemperatureC = 32
        };
    }

    [Test]
    public void ToDto_Executed_ReturnsWeatherForecastDtoWithCorrectValues()
    {
        // arrange

        // act
        var result = _sut.ToDto();

        // assert
        result.Should().BeOfType<WeatherForecastDto>();
        result.Id.Should().Be(_sut.Id);
        result.Date.Should().Be(_sut.Date);
        result.Summary.Should().Be(_sut.Summary);
        result.TemperatureC.Should().Be(_sut.TemperatureC);
        result.TemperatureF.Should().Be(_sut.TemperatureF);
    }
}
