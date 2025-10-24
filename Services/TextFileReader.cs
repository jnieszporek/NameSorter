using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;
public class TextFileReader : INameReader
{
    private readonly string _filePath;

    public TextFileReader(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public async Task<IList<Name>> ReadNamesAsync()
    {
        if (!File.Exists(_filePath))
            throw new FileNotFoundException($"Input file not found: {_filePath}");

        var lines = await File.ReadAllLinesAsync(_filePath);
        var names = new List<Name>();

        foreach (var line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                try
                {
                    names.Add(Name.Parse(line));
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidDataException($"Invalid name format: {line}", ex);
                }
            }
        }

        return names;
    }
}
