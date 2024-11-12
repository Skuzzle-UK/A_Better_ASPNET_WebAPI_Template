using Example.Controllers.Dtos;
using Example.Models;
using Example.Storage.Entities;
using ExampleTests.TestsExtensions;
using FluentAssertions;
using Mapster;

namespace ExampleTests.Mapping;

[TestFixture]
public sealed class WeatherForecastMappingTests // Yup and mapping can be tested
{
    private readonly WeatherForecast _sut;

    public WeatherForecastMappingTests()
    {
        _sut = new()
        {
            Id = Guid.NewGuid(),
            Date = DateOnly.MinValue,
            Summary = "A Summary",
            TemperatureC = 32
        };
    }

    // Regions used to split this file. If much larger then recommend partial classes instead
    #region Forward mapping
    [Test]
    public void WeatherForecast_MapToWeatherForecastDto_AllPropertiesAsExpected()
    {
        // arrange

        // act
        var result = _sut.Adapt<WeatherForecastDto>();

        // assert
        result.Date.Should().Be(_sut.Date);
        result.Summary.Should().Be(_sut.Summary);
        result.TemperatureC.Should().Be(_sut.TemperatureC);
        result.TemperatureF.Should().Be(_sut.TemperatureF);
    }

    [Test]
    public void WeatherForecast_MapToWeatherForecastEntity_AllPropertiesAsExpected()
    {
        // arrange

        // act
        var result = _sut.Adapt<WeatherForecastEntity>();

        // assert
        result.Date.Should().Be(_sut.Date);
        result.CreatedOn.Should().NotBeNull();
        result.DeletedOn.Should().BeNull();
        result.UpdatedOn.Should().BeNull();
        result.Summary.Should().Be(_sut.Summary);
        result.Id.Should().Be(_sut.Id);
        result.TemperatureC.Should().Be(32);
    }
    #endregion

    #region Reverse mapping
    [Test]
    public void WeatherForecastDto_MapToWeatherForecast_AllPropertiesAsExpected()
    {
        // arrange
        var dto = _sut.Adapt<WeatherForecastDto>();

        // act
        var result = dto.Adapt<WeatherForecast>();

        // assert
        result.Summary.Should().Be(_sut.Summary);
        result.TemperatureC.Should().Be(_sut.TemperatureC);
        result.TemperatureF.Should().Be(_sut.TemperatureF);
        result.Date.Should().Be(_sut.Date);
        result.Id.Should().Be(_sut.Id);
    }

    [Test]
    public void WeatherForecastEntity_MapToWeatherForecast_AllPropertiesAsExpected()
    {
        // arrange
        var entity = _sut.Adapt<WeatherForecastEntity>();

        // act
        var result = entity.Adapt<WeatherForecast>();

        // assert
        result.Summary.Should().Be(_sut.Summary);
        result.TemperatureC.Should().Be(_sut.TemperatureC);
        result.TemperatureF.Should().Be(_sut.TemperatureF);
        result.Date.Should().Be(_sut.Date);
        result.Id.Should().Be(_sut.Id);
    }
    #endregion
}
