# Name Sorter

A .NET 8 console application that sorts names by last name, then by given names.

## Features

- Sorts names first by last name, then by given names
- Handles names with 1-3 given names
- Outputs results to console and file
- Unit tested

## Build & Run

From the solution root:

- Build:
  - `dotnet build`

- Run the app (example):
  - `dotnet run --project . -- ./unsorted-names-list.txt`
  - or from the compiled binary: `dotnet NameSorter.exe ./unsorted-names-list.txt`

The program writes `sorted-names-list.txt` in the working directory and prints the sorted list to the console.

## Tests

Run unit tests:

- `dotnet test`

## Notes

- Target framework: .NET 8
- Recommended: Push the repository to GitHub and enable CI that runs `dotnet build` and `dotnet test`.