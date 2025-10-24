using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services;

public class FasterNameSorter : INameSorter
{
    public IList<Name> SortNames(IList<Name> names)
    {
        if (names == null)
            throw new ArgumentNullException(nameof(names));

        return names
            .OrderBy(name => name.LastName, StringComparer.OrdinalIgnoreCase)
            .ThenBy(name => name.GivenNames, new GivenNamesComparer())
            .ToList();
    }
    public class GivenNamesComparer : IComparer<IReadOnlyList<string>>
    {
        public int Compare(IReadOnlyList<string>? x, IReadOnlyList<string>? y)
        {
            // Handle nulls
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Compare element by element
            for (int i = 0; i < Math.Min(x.Count, y.Count); i++)
            {
                int result = StringComparer.OrdinalIgnoreCase.Compare(x[i], y[i]);
                if (result != 0)
                    return result;
            }

            // If we get here, the common elements are equal. Then the shorter list comes first.
            return x.Count.CompareTo(y.Count);
        }
    }
}
