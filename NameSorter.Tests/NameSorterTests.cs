using NameSorter.Models;
using NameSorter.Services;

namespace NameSorter.Tests;

public class NameSorterTests
{
    [Fact]
    public void SortNames_WhenGivenUnsortedList_ReturnsSortedList()
    {
        // Arrange
        var names = new List<Name>
        {
            Name.Parse("Janet Parsons"),
            Name.Parse("Vaughn Lewis"),
            Name.Parse("Adonis Julius Archer")
        };

        var sorter = new Services.NameSorter();

        // Act
        var result = sorter.SortNames(names);

        // Assert
        Assert.Equal("Adonis Julius Archer", result[0].ToString());
        Assert.Equal("Vaughn Lewis", result[1].ToString());
        Assert.Equal("Janet Parsons", result[2].ToString());
    }

    [Fact]
    public void SortNames_WhenSameLastName_OrdersByGivenNames()
    {
        // Arrange
        var names = new List<Name>
        {
            Name.Parse("John Adam Smith"),
            Name.Parse("John Zachary Smith"),
            Name.Parse("John Smith")
        };

        var sorter = new Services.NameSorter();

        // Act
        var result = sorter.SortNames(names);

        // Assert
        Assert.Equal("John Smith", result[0].ToString());
        Assert.Equal("John Adam Smith", result[1].ToString());
        Assert.Equal("John Zachary Smith", result[2].ToString());
    }
}