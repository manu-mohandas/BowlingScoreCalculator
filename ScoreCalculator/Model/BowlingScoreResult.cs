using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Model
{
    public class BowlingScoreResult
    {
        public IList<string> FrameProgressScores { get; set; }
        public bool GameCompleted { get; set; }
    }
}
