using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Disc_Golf_Tracker
{
    public class Scorecard
    {
        public Hole Hole { get; set; }
        public int CurrentScore { get; set; }
        
        public void ShowScoreCard(Player player)
        {
            player.PlayerHoleScores.Sort();

            foreach(Hole hole in player.PlayerHoleScores)
            {
                Console.WriteLine();
                Console.WriteLine(hole);
            }
        }

    }
}
