using Example.Models;
using Example.Storage.Entities;
using FluentAssertions;
using FluentResults;
using Moq;

namespace ExampleTests.Services;

[TestFixture]
public sealed partial class WeatherForecastServiceTests
{
    [Test]
    public async Task GetWeeklyForecastsAsync_RepositorySuccessful_ReturnsOkResultWithListOfWeatherForecast()
    {
        // arrange
        _repositoryMock // Format like this using multiline
            .Setup(x => x.GetManyAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Ok(new List<WeatherForecastEntity>()));

        // act
        var result = await _sut.GetWeeklyForecastsAsync(It.IsAny<CancellationToken>());

        // assert
        result.IsSuccess.Should().BeTrue();
        result.Should().BeOfType<Result<List<WeatherForecast>>>();
        result.Value.Should().NotBeNull();
    }

    [Test]
    public async Task GetWeeklyForecastAsync_RepositoryFails_ReturnsFailResult()
    {
        // arrange
        _repositoryMock // Format like this using multiline
            .Setup(x => x.GetManyAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Fail("oops"));

        // act
        var result = await _sut.GetWeeklyForecastsAsync(It.IsAny<CancellationToken>());

        // assert
        result.IsFailed.Should().BeTrue();
        result.Errors.First().Message.Should().Be("oops");
    }
}
