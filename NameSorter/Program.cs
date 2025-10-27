using NameSorter.Services;
using NameSorter.Core;

class Program
{
    static async Task<int> Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: NameSorter <input-file-path>");
            return 1;
        }

        try
        {
            var inputFilePath = args[0];
            var outputFilePath = "sorted-names-list.txt";


            var reader = new TextFileReader(inputFilePath);
            //var sorter = new NameSorter.Services.NameSorter();
            var sorter = new FasterNameSorter();
            var consoleWriter = new ConsoleWriter();
            var fileWriter = new TextFileWriter(outputFilePath);
            var compositeWriter = new CompositeWriter(consoleWriter, fileWriter);

            var processor = new NameProcessor(reader, sorter, compositeWriter);

            await processor.ProcessAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return 1;
        }

    }
}