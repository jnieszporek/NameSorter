using NameSorter.Models;
namespace NameSorter.Interfaces;
public interface INameWriter
{
    Task WriteNamesAsync(IList<Name> names);
}
