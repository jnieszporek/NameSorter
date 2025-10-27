namespace NameSorter.Models;

public class Name
{
    public IReadOnlyList<string> GivenNames { get; }
    public string LastName { get; }

    public Name(IEnumerable<string> givenNames, string lastName)
    {
        if (givenNames == null || !givenNames.Any())
            throw new ArgumentException("At least one given name is required", nameof(givenNames));

        if (givenNames.Count() > 3)
            throw new ArgumentException("Maximum of 3 given names allowed", nameof(givenNames));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required", nameof(lastName));

        GivenNames = givenNames.ToList().AsReadOnly();
        LastName = lastName.Trim();
    }

    public override string ToString() => $"{string.Join(" ", GivenNames)} {LastName}";

    public static Name Parse(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name cannot be empty", nameof(fullName));

        var nameParts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (nameParts.Length < 2)
            throw new ArgumentException("Name must have at least one given name and a last name", nameof(fullName));

        if (nameParts.Length > 4)
            throw new ArgumentException("Name can have at most 3 given names and one last name", nameof(fullName));

        var givenNames = nameParts.Take(nameParts.Length - 1);
        var lastName = nameParts.Last();

        return new Name(givenNames, lastName);
    }
}