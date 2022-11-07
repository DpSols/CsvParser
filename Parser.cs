using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace CsvParser
{
    internal static class Parser
    {
        public static List<ChessPlayer> Parse(FileStream file)
        {
            var chessPlayers = new List<ChessPlayer>();
            using (var parser = new TextFieldParser(file))
            {
                // reading lines from file into List
                var lines = new List<string>();
                while (!parser.EndOfData)
                {
                    //Processing row
                    lines.Add(parser.ReadLine());
                }
                foreach (var line in lines.Skip<string>(1))
                {
                    string[] fields = line.Split(";");

                    
                    var player = new ChessPlayer();
                    
                    // parse Rank
                    if (ushort.TryParse(fields[0], out var rankParsed))
                    {
                        player.Rank = rankParsed;
                    }
                    else
                    {

                    }

                    // parse name
                    player.Name = fields[1];

                    // parse title
                    if (fields[2].Length == 1)
                    {
                        player.Title = char.Parse(fields[2]);
                    }
                    else
                    {
                        player.Title = '\0';
                    }

                    //parse country
                    player.Country = fields[3];

                    //parse rating
                    if (ushort.TryParse(fields[4], out var ratingParsed))
                    {
                        player.Rating = ratingParsed;
                    }
                    else
                    {
                        player.Rating = 0;
                    }

                    //parse games
                    if (ushort.TryParse(fields[5], out var gamesParsed))
                    {
                        player.Games = gamesParsed;
                    }
                    else
                    {
                        player.Games = 0;
                    }

                    // parse year
                    if (ushort.TryParse(fields[6], out var yearParsed))
                    {
                        player.BYear = yearParsed;
                    }
                    else
                    {
                        player.BYear = 0;
                    }
                    chessPlayers.Add(player);
                }
            }
            return chessPlayers;
        }
    }
}
