using NameSorter.Interfaces;

namespace NameSorter.Core;

public class NameProcessor
{
    private readonly INameReader _reader;
    private readonly INameSorter _sorter;
    private readonly INameWriter _writer;

    public NameProcessor(INameReader reader, INameSorter sorter, INameWriter writer)
    {
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        _sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
    }

    public async Task ProcessAsync()
    {
        var names = await _reader.ReadNamesAsync();
        var sortedNames = _sorter.SortNames(names);
        await _writer.WriteNamesAsync(sortedNames);
    }
}