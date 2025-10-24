using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;

public class NameSorter : INameSorter
{
    public IList<Name> SortNames(IList<Name> names)
    {
        if (names == null)
            throw new ArgumentNullException(nameof(names));

        return names
            .OrderBy(name => name.LastName)
            .ThenBy(name => string.Join(" ", name.GivenNames))
            .ToList();
    }
}
