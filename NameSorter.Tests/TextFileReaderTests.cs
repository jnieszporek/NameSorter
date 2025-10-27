using NameSorter.Services;

namespace NameSorter.Tests;

public class TextFileReaderTests : IDisposable
{
    private readonly string _testFilePath = "test-input.txt";

    public void Dispose()
    {
        if (File.Exists(_testFilePath))
            File.Delete(_testFilePath);
    }

    [Fact]
    public async Task ReadNamesAsync_WhenFileExists_ReturnsNames()
    {
        // Arrange
        await File.WriteAllLinesAsync(_testFilePath, new[] { "John Doe", "Jane Smith" });
        var reader = new TextFileReader(_testFilePath);

        // Act
        var names = await reader.ReadNamesAsync();

        // Assert
        Assert.Equal(2, names.Count);
        Assert.Equal("John Doe", names[0].ToString());
    }
}