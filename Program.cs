using CsvParser;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        // open stream for csv file
        string filePath = "C:\\Users\\Nod\\Desktop\\internTask\\Top100ChessPlayers.csv";
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

        using ILoggerFactory loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
        ILogger logger = loggerFactory.CreateLogger<ChessPlayer>();

        if (fileStream != null)
        {
            var firstTenPlayers = Parser.Parse(fileStream)
            .Where(player => player.BYear < 1980)
            .Take(10);

            foreach (ChessPlayer player in firstTenPlayers)
            {
                logger.LogInformation(player.ToString());
            }
        }
    }
}