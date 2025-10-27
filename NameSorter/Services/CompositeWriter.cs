using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;

public class CompositeWriter : INameWriter
{
    private readonly IEnumerable<INameWriter> _writers;

    public CompositeWriter(params INameWriter[] writers)
    {
        _writers = writers ?? throw new ArgumentNullException(nameof(writers));
    }

    public async Task WriteNamesAsync(IList<Name> names)
    {
        var tasks = _writers.Select(writer => writer.WriteNamesAsync(names));
        await Task.WhenAll(tasks);
    }
}