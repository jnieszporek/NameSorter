using NameSorter.Models;
namespace NameSorter.Interfaces;

public interface INameSorter
{
    IList<Name> SortNames(IList<Name> names);
}