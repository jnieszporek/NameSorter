using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;

public class ConsoleWriter : INameWriter
{
    public Task WriteNamesAsync(IList<Name> names)
    {
        if (names == null)
            throw new ArgumentNullException(nameof(names));

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        return Task.CompletedTask;
    }
}