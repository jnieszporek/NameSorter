using NameSorter.Models;

namespace NameSorter.Tests;

public class NameTests
{
    [Theory]
    [InlineData("John Doe", new[] { "John" }, "Doe")]
    [InlineData("John Michael Doe", new[] { "John", "Michael" }, "Doe")]
    [InlineData("John Michael David Doe", new[] { "John", "Michael", "David" }, "Doe")]
    public void Parse_ValidNames_ReturnsCorrectName(string input, string[] expectedGivenNames, string expectedLastName)
    {
        // Act
        var name = Name.Parse(input);

        // Assert
        Assert.Equal(expectedGivenNames, name.GivenNames);
        Assert.Equal(expectedLastName, name.LastName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("Single")]
    public void Parse_InvalidNames_ThrowsException(string invalidName)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Name.Parse(invalidName));
    }
}