using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    internal sealed class ChessPlayer
    {
        public ushort Rank { get; internal set; }
        public string Name { get; internal set; }
        public char Title { get; internal set; }
        public string Country { get; internal set; }
        public ushort Rating { get; internal set; }
        public ushort Games { get; internal set; }
        public ushort BYear { get; internal set; }

        public override string ToString()
        {
            string objToString = string.Format("Rank: {0}; Name: {1}; Title: {2}; Country: {{t}}; Rating: {4}; Games: {5}; BYear: {6}",
                Rank, Name, Title, Country, Rating, Games, BYear);
            return objToString;
        }
    }
}
