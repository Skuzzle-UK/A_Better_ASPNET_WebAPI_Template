using Example.Settings;
using FluentAssertions;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace ExampleTests.Settings;

// CHECK THIS OUT!!! validated settings with tests.. WTF!!!
[TestFixture]
public sealed class WeatherSettingsTests
{
    [Test]
    public void RequiredString_Missing_ValidationFails()
    {
        // arrange
        var _sut = Options.Create(new WeatherSettings()
        {
            ExampleSettingBool = true,
            NotRequiredString = "string"
        });

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(_sut.Value);

        // act
        var result = Validator.TryValidateObject(_sut.Value, validationContext, validationResults, true);

        // assert
        result.Should().BeFalse();
    }

    [Test]
    public void RequiredString_IsNotPhoneNumber_ValidationFails()
    {
        // arrange
        var _sut = Options.Create(new WeatherSettings()
        {
            ExampleSettingBool = true,
            NotRequiredString = "string",
            RequiredString = "not a phone number"
        });

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(_sut.Value);

        // act
        var result = Validator.TryValidateObject(_sut.Value, validationContext, validationResults, true);

        // assert
        result.Should().BeFalse();
    }

    [Test]
    public void RequiredString_AllPropertiesCorrect_ValidationSuccessful()
    {
        // arrange
        var _sut = Options.Create(new WeatherSettings()
        {
            ExampleSettingBool = true,
            NotRequiredString = "string",
            RequiredString = "07000000000"
        });

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(_sut.Value);

        // act
        var result = Validator.TryValidateObject(_sut.Value, validationContext, validationResults, true);

        // assert
        result.Should().BeTrue();
    }
}