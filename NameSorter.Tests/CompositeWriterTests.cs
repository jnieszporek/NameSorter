using NameSorter.Services;
using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Tests;

public class CompositeWriterTests
{
    private class InMemoryWriter : INameWriter
    {
        public IList<Name>? Written { get; private set; }
        public Task WriteNamesAsync(IList<Name> names)
        {
            Written = names.ToList();
            return Task.CompletedTask;
        }
    }

    [Fact]
    public async Task WriteNamesAsync_CallsAllWriters()
    {
        // Arrange
        var names = new List<Name> { Name.Parse("Alpha Beta") };
        var w1 = new InMemoryWriter();
        var w2 = new InMemoryWriter();
        var composite = new CompositeWriter(w1, w2);

        // Act
        await composite.WriteNamesAsync(names);

        // Assert
        Assert.NotNull(w1.Written);
        Assert.NotNull(w2.Written);
        Assert.Equal(names[0].ToString(), w1.Written![0].ToString());
        Assert.Equal(names[0].ToString(), w2.Written![0].ToString());
    }
}