using System;
using System.Collections.Generic;
using System.Text;

namespace Disc_Golf_Tracker
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Hole> PlayerHoleScores { get; set; } = new List<Hole>();
        public int CurrentScore { get; private set; } = 0;

        public void ModifyCurrentScore(int holeScore)
        {
            CurrentScore += holeScore;
        }

    }
}
