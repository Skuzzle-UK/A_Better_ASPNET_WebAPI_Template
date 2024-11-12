// This is how I would place extensions / helpers or whatever might be required by the tests.
using FluentAssertions.Primitives;

namespace ExampleTests.TestsExtensions;

internal static class DateTimeOffsetAssertionsExtensions
{
    internal static bool NotBeNull(this DateTimeOffsetAssertions value) => value is not null;
}
