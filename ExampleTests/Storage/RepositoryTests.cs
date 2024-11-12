using Example.Storage;
using Example.Storage.DbContexts;
using Example.Storage.Entities;
using FluentAssertions;
using FluentResults;
using Microsoft.Extensions.Logging;
using Moq;

namespace ExampleTests.Storage;

[TestFixture]
public sealed class RepositoryTests
{
    private readonly Repository<WeatherForecastEntity> _sut; // Testing on whatever type you fancy as generic class

    private readonly Mock<ILogger<Repository<WeatherForecastEntity>>> _loggerMock;
    private readonly Mock<IDbContext> _dbContextMock;

    public RepositoryTests()
    {
        _loggerMock = new();
        _dbContextMock = new();

        _sut = new(_loggerMock.Object, _dbContextMock.Object);
    }

    [Test]
    public async Task GetManyAsync_DbContextSuccessful_ReturnsOkResultWithListOfT()
    {
        // arrange
        _dbContextMock
            .Setup(x => x.GetManyAsync<WeatherForecastEntity>(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<WeatherForecastEntity> ());

        // act
        var result = await _sut.GetManyAsync(It.IsAny<CancellationToken>());

        // assert
        result.IsSuccess.Should().BeTrue();
        result.Should().BeOfType<Result<List<WeatherForecastEntity>>>();
    }

    [Test]
    public async Task GetManyAsync_DbContextFails_ReturnsFailResultWithExceptionMessageAndLogsError()
    {
        // arrange
        var exceptionMessage = "Scary message!!";

        _dbContextMock
            .Setup(x => x.GetManyAsync<WeatherForecastEntity>(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception(exceptionMessage));

        // act
        var result = await _sut.GetManyAsync(It.IsAny<CancellationToken>());

        // assert
        result.IsFailed.Should().BeTrue();
        result.Errors.First().Message.Should().Be(exceptionMessage);
    }

}
