using NameSorter.Services;
using NameSorter.Core;
using NameSorter.Models;

namespace NameSorter.Tests;

public class NameProcessorIntegrationTests : IDisposable
{
    private readonly string _inputPath = "integration-input.txt";
    private readonly string _outputPath = "integration-output.txt";

    public void Dispose()
    {
        if (File.Exists(_inputPath))
            File.Delete(_inputPath);
        if (File.Exists(_outputPath))
            File.Delete(_outputPath);
    }

    [Fact]
    public async Task ProcessAsync_ReadsSortsAndWritesOutputFile()
    {
        // Arrange
        await File.WriteAllLinesAsync(_inputPath, new[]
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer"
        });

        var reader = new TextFileReader(_inputPath);
        var sorter = new NameSorter.Services.NameSorter();
        var writer = new TextFileWriter(_outputPath);
        var processor = new NameProcessor(reader, sorter, writer);

        // Act
        await processor.ProcessAsync();

        // Assert
        var lines = await File.ReadAllLinesAsync(_outputPath);
        Assert.Equal(3, lines.Length);
        Assert.Equal("Adonis Julius Archer", lines[0]);
        Assert.Equal("Vaughn Lewis", lines[1]);
        Assert.Equal("Janet Parsons", lines[2]);
    }
}