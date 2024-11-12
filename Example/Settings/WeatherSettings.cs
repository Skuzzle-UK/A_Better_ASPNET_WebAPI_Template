// Warnings disabled as we need to ensure that string is not null but don't want a project full of warnings
#pragma warning disable
using System.ComponentModel.DataAnnotations;
using Example;
using Example.Settings;

namespace Example.Settings;

public sealed class WeatherSettings
{
    public bool ExampleSettingBool { get; set; }

    // This has been thought about. It should not be null and if config missing should never be empty
    [Required, Phone]
    public string RequiredString { get; set; }

    // This one declared nullable as it is acceptable that this is not configured
    public string? NotRequiredString { get; set; }
}
