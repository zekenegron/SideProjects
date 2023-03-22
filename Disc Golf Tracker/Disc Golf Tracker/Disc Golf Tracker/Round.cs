using System;
using System.Collections.Generic;
using System.Text;

namespace Disc_Golf_Tracker
{
    public class Round
    {
        public int RoundId { get; set; }
        public int CourseId { get; set; }
        public DateTime DatePlayed { get; set; }
        public int FinalScore { get; set; }
    }
}
