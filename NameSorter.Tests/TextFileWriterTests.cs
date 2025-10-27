using NameSorter.Services;
using NameSorter.Models;

namespace NameSorter.Tests;

public class TextFileWriterTests : IDisposable
{
    private readonly string _testFilePath = "test-output.txt";

    public void Dispose()
    {
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);
    }

    [Fact]
    public async Task WriteNamesAsync_WritesLinesToFile()
    {
        // Arrange
        var names = new List<Name>
        {
            Name.Parse("John Doe"),
            Name.Parse("Jane Smith")
        };

        var writer = new TextFileWriter(_testFilePath);

        // Act
        await writer.WriteNamesAsync(names);

        // Assert
        Assert.True(File.Exists(_testFilePath));
        var lines = await File.ReadAllLinesAsync(_testFilePath);
        Assert.Equal(2, lines.Length);
        Assert.Equal("John Doe", lines[0]);
        Assert.Equal("Jane Smith", lines[1]);
    }
}