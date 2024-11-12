using Example.Controllers.Dtos;
using Example.Extensions;
using FluentAssertions;

namespace ExampleTests.Extensions;

[TestFixture]
public sealed class WeatherForecastDtoExtensionsTests // Yes we can test these too like regular methods
{
    [Test, TestCaseSource(nameof(WeatherForecastDtoTestCases))]
    public void CloudSeed_GivenAnyWeatherForecastDto_Subtracts5FromTemperatureC(WeatherForecastDto weatherForecastDto)
    {
        // arrange
        var initialValue = weatherForecastDto.TemperatureC;

        // act
        var result = weatherForecastDto.CloudSeed();
        
        // assert
        result.TemperatureC.Should().Be(initialValue - 5);

        // TODO: Left a bug here on purpose, lets see who can solve it. /nb
        // A test case passes, but the doesn't match the desired intention.
        // Hint - The 3rd test case exposes the problem if you know what to look for. Happy Hacking
    }

    public static IEnumerable<WeatherForecastDto> WeatherForecastDtoTestCases
    {
        get
        {
            yield return new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(
                    DateTimeOffset.UtcNow.Year,
                    DateTimeOffset.UtcNow.Month,
                    DateTimeOffset.UtcNow.Day),
                Summary = "A Summary",
                TemperatureC = 32,
                TemperatureF = 100000,
            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(
                    DateTimeOffset.UtcNow.Year,
                    DateTimeOffset.UtcNow.Month,
                    DateTimeOffset.UtcNow.Day),
                Summary = "A N Other Summary",
                TemperatureC = 23,
                TemperatureF = 5,
            };

            yield return new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(
                    DateTimeOffset.UtcNow.Year,
                    DateTimeOffset.UtcNow.Month,
                    DateTimeOffset.UtcNow.Day),
                Summary = "A N Other Summary",
                TemperatureC = int.MinValue,
                TemperatureF = 5,
            };
        }
    }
}
