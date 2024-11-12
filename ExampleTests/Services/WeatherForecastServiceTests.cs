using Example.Services;
using Example.Settings;
using Example.Storage;
using Example.Storage.Entities;
using Microsoft.Extensions.Options;
using Moq;

namespace ExampleTests.Services;

[TestFixture]
public sealed partial class WeatherForecastServiceTests
{
    private readonly WeatherForecastService _sut;

    // Mock at end of name so that getting to variable name auto complete is quicker than if loads if mocks all start with mock
    private readonly Mock<IRepository<WeatherForecastEntity>> _repositoryMock;

    public WeatherForecastServiceTests()
    {
        _repositoryMock = new();

        // This is how to configure settings to test classes that use IOptions
        var settings = Options.Create(new WeatherSettings()
        {
            ExampleSettingBool = true,
            NotRequiredString = "not required",
            RequiredString = "required"
        });

        _sut = new(_repositoryMock.Object, settings);
    }
}
