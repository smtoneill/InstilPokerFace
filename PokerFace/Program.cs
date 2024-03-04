using PokerFace.Consumers;
using PokerFace.Consumers.Console;
using PokerFace.Data.DataSource;
using PokerFace.Data.DataSource.File;
using PokerFace.Data.Parser;
using PokerFace.Evaluators;
using PokerFace.Formatters;
using PokerFace.Service;

class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("The filepath parameter was not specified.");
            return;
        }

        try
        {

            IDataSource dataSource = BuildDataSource(args[0]);
            IHandEvaluator handEvaluator = new HandEvaluator();
            IHandConsumer consumer = BuildConsumer();

            PokerHandService service = new(dataSource, handEvaluator, consumer);
            service.Process();
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }


    private static IDataSource BuildDataSource(string filePath)
    {
        FileSystem fileSystem = new();
        StringParser parser = new();

        return new TextFileDataSource(fileSystem, parser, filePath);
    }

    private static IHandConsumer BuildConsumer()
    {
        SimpleStringFormatter formatter = new();
        return new ConsoleHandConsumer(formatter);
    }
}