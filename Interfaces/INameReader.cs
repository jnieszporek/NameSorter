using NameSorter.Models;

namespace NameSorter.Interfaces;

public interface INameReader
{
    Task<IList<Name>> ReadNamesAsync();
}
