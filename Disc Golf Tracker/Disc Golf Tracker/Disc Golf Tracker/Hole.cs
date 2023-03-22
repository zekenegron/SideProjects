using System;
using System.Collections.Generic;
using System.Text;

namespace Disc_Golf_Tracker
{
    public class Hole
    {
        public string HoleNumber { get; set; }
        public int HoleScore { get; set; }

        public Hole (string holeNumber, int holeScore)
        {
            this.HoleNumber = holeNumber;
            this.HoleScore = holeScore;
        }

        public override string ToString()
        {
            return $"{HoleNumber} {HoleScore}";
        }

    }
}
