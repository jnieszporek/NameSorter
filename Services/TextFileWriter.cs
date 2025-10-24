using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;

public class TextFileWriter : INameWriter
{
    private readonly string _filePath;

    public TextFileWriter(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public async Task WriteNamesAsync(IList<Name> names)
    {
        if (names == null)
            throw new ArgumentNullException(nameof(names));

        var lines = names.Select(name => name.ToString()).ToArray();
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}